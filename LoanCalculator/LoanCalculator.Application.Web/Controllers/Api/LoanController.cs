using LoanCalculator.Application.Web.Models.DataTransferObject;
using LoanCalculator.DataAccess.Core;
using LoanCalculator.DataAccess.Core.Domain;
using LoanCalculator.DataAccess.Persistence;
using LoanCalculator.DataAccess.Persistence.EFContext;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LoanCalculator.Application.Web.Controllers.Api
{
    public class LoanController : ApiController
    {
        private readonly IUnitOfWork _uow;

        public LoanController()
        {
            _uow = new UnitOfWork(new LoanDBContext());
        }

        [HttpGet]
        [Route("api/loan/form/{link}")]
        public async Task<HttpResponseMessage> GetLoanFormByGeneratedLink(string link)
        {
            var loanForm = await _uow.Loans.GetLoanFormByGeneratedLink(link);

            return Request.CreateResponse(HttpStatusCode.OK, loanForm);
        }

        [HttpPost]
        [Route("api/loan/form/")]
        public async Task<HttpResponseMessage> RegisterLoanForm(LoanFormDto model)
        {
            string generatedLink = "";

            var existingLoanForm = await _uow.Loans.GetLoanFormByPersonalDetailsAsync(model.FirstName, model.LastName, model.DateOfBirth);

            if (existingLoanForm != null)
            {
                generatedLink = existingLoanForm.GeneratedLink;
            }
            else
            {
                var entity = new LoanForm
                {
                    Title = model.Title,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    Mobile = model.Mobile,
                    Email = model.Email,
                    PrincipalAmount = model.AmountRequired,
                    TotalMonthTerms = model.Term,
                    GeneratedLink = Guid.NewGuid().ToString(),
                    EstablishmentFee = 300
                };

                _uow.Loans.Add(entity);
                await _uow.CompleteAsync();
            }

            var uriBuilder = new UriBuilder($"{Url.Content("~/")}Home/LoanCalculator");
            uriBuilder.Query = $"link={generatedLink}";

            var response = Request.CreateResponse(HttpStatusCode.Moved);
            response.Headers.Location = new Uri(uriBuilder.ToString());

            return response;
        }

        [HttpPut]
        [Route("api/loan/form")]
        public async Task<HttpResponseMessage> UpdateLoanForm(LoanFormDto model)
        {
            var loanForm = await _uow.Loans.GetAsync(i => i.LoanFormId == model.LoanFormId);

            loanForm.Title = model.Title;
            loanForm.FirstName = model.FirstName;
            loanForm.LastName = model.LastName;
            loanForm.DateOfBirth = model.DateOfBirth;
            loanForm.Mobile = model.Mobile;
            loanForm.Email = model.Email;
            loanForm.PrincipalAmount = model.AmountRequired;
            loanForm.TotalMonthTerms = model.Term;
            loanForm.ProductId = model.ProductId;

            await _uow.CompleteAsync();

            return Request.CreateResponse(HttpStatusCode.OK, loanForm);
        }
    }
}
