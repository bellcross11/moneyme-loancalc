using LoanCalculator.BusinessLayer.DataTransferObjects;
using LoanCalculator.BusinessLayer.Services;
using LoanCalculator.BusinessLayer.Services.IServices;
using LoanCalculator.DataAccessLayer.EFContext;
using LoanCalculator.DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LoanCalculator.Application.Web.Controllers.Api
{
    public class LoanController : ApiController
    {
        private readonly ICustomerService _customerService;

        public LoanController()
        {
            _customerService = new CustomerService(new UnitOfWork(new LoanDBContext()));
        }

        [HttpPost]
        [Route("api/loan")]
        public async Task<HttpResponseMessage> AddCustomer(CustomerDto model)
        {
            var generatedLink = await _customerService.AddCustomerThenGenerateLink(model);

            return Request.CreateResponse(HttpStatusCode.OK, generatedLink);
        }

        [HttpGet]
        [Route("api/loan/{link}")]
        public async Task<HttpResponseMessage> GetCustomerAndLoanDetails(string link)
        {
            var customerDetails = await _customerService.GetCustomerAndLoanDetails(link);

            return Request.CreateResponse(HttpStatusCode.OK, customerDetails);
        }

        [HttpPut]
        [Route("api/loan")]
        public async Task<HttpResponseMessage> UpdateCustomerDetails(CustomerDto model)
        {
            await _customerService.UpdateCustomerDetails(model);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
