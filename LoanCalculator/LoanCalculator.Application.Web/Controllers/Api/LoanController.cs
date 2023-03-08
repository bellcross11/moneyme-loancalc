using LoanCalculator.Application.Web.Helpers;
using LoanCalculator.Application.Web.Models.DataTransferObject;
using LoanCalculator.DataAccess.Core;
using LoanCalculator.DataAccess.Core.Common;
using LoanCalculator.DataAccess.Core.Domain;
using LoanCalculator.DataAccess.Persistence;
using LoanCalculator.DataAccess.Persistence.EFContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LoanCalculator.Application.Web.Controllers.Api
{
    public class LoanController : ApiController
    {
        private readonly IUnitOfWork _uow;
        private readonly ILoanComputation _compute;

        public LoanController()
        {
            _uow = new UnitOfWork(new LoanDBContext());
            _compute = new ComputeLoan();
        }

        [HttpGet]
        [Route("api/loan/form/generatedlink")]
        public async Task<HttpResponseMessage> GetGeneratedLinkByPersonalDetailsAsync(string FirstName, string LastName, DateTime DateOfBirth)
        {
            var loanForm = await _uow.Loans.GetLoanFormByPersonalDetailsAsync(FirstName, LastName, DateOfBirth);

            if (loanForm == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No Customer Found");

            var uriBuilder = new UriBuilder($"{Url.Content("~/")}Home/LoanCalculator");
            uriBuilder.Query = $"link={loanForm.GeneratedLink}";

            return Request.CreateResponse(HttpStatusCode.OK, uriBuilder.Uri);
        }

        [HttpGet]
        [Route("api/loan/form/{link}")]
        public async Task<HttpResponseMessage> GetLoanFormByGeneratedLink(string link)
        {
            var loanForm = await _uow.Loans.GetLoanFormByGeneratedLink(link);

            var result = new LoanFormDto { 
                LoanFormId = loanForm.LoanFormId,
                Title = loanForm.Title,
                FirstName = loanForm.FirstName,
                LastName = loanForm.LastName,
                DateOfBirth = loanForm.DateOfBirth,
                Mobile = loanForm.Mobile,
                Email = loanForm.Email,
                Term = loanForm.TotalMonthTerms,
                AmountRequired = loanForm.PrincipalAmount,
                ProductId = loanForm.ProductId
            };

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/loan/form")]
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

        [HttpGet]
        [Route("api/loan/form/calculate/{link}")]
        public async Task<HttpResponseMessage> CalculateLoan(string link)
        {
            var computedLoan = _compute.GetTotalComputation(await _uow.Loans.GetLoanFormByGeneratedLink(link));

            var result = new LoanFormDto
            {
                FirstName = computedLoan.FirstName,
                LastName = computedLoan.LastName,
                DateOfBirth = computedLoan.DateOfBirth,
                Mobile = computedLoan.Mobile,
                Email = computedLoan.Email,
                Term = computedLoan.TotalMonthTerms,
                AmountRequired = computedLoan.PrincipalAmount,
                EstablishmentFee = computedLoan.EstablishmentFee,
                ProductId = computedLoan.ProductId,
                MonthlyRepayment = computedLoan.MonthlyRepayment,
                MonthlyRepaymentStr = computedLoan.MonthlyRepayment.ToString("#.##"),
                TotalRepayment = computedLoan.TotalRepayment,
                TotalRepaymentStr = computedLoan.TotalRepayment.ToString("#.##"),
                TotalInterest = computedLoan.TotalInterest,
                TotalInterestStr = string.IsNullOrEmpty(computedLoan.TotalInterest.ToString("#.##")) ? "0" : computedLoan.TotalInterest.ToString("#.##")
            };

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("api/loan/form/applyloan/{link}")]
        public async Task<HttpResponseMessage> ApplyLoan(string link)
        {
            var errorMessages = new List<string>();

            var computedLoan = _compute.GetTotalComputation(await _uow.Loans.GetLoanFormByGeneratedLink(link));

            // 1. check blacklisted mobile numbers
            if (BlackListed.MobileNumbers.Exists(i => i == computedLoan.Mobile))
                errorMessages.Add("Your Mobile Number is blacklisted");

            // 2. check blacklisted email domains
            if (BlackListed.EmailDomains.Exists(i => i == computedLoan.Email.Split('@')[1]))
                errorMessages.Add("Your Email Domain is blacklisted");

            // 3. check age if 18 years old above
            DateTime adjustedDOB = computedLoan.DateOfBirth.AddDays(2);
            int adjustedAge = DateTime.Today.Year - adjustedDOB.Year;

            if (adjustedDOB > DateTime.Today.AddYears(-adjustedAge))
                adjustedAge--;

            if (adjustedAge < 18)
                errorMessages.Add("You must be atleast 18 years old and above for applying loan");

            if (errorMessages.Count > 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest, errorMessages);

            
            // Success
            var loanForm = await _uow.Loans.GetAsync(i => i.LoanFormId == computedLoan.LoanFormId);
            loanForm.MonthlyRepayment = computedLoan.MonthlyRepayment;
            loanForm.TotalRepayment = computedLoan.TotalRepayment;
            loanForm.TotalInterest = computedLoan.TotalInterest;   
            
            // this can be used for applying another loan with the same customer
            loanForm.isLoanSuccess = true;

            await _uow.CompleteAsync();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
