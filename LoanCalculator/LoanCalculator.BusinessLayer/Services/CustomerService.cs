using LoanCalculator.BusinessLayer.DataTransferObjects;
using LoanCalculator.BusinessLayer.Services.IServices;
using LoanCalculator.DataAccessLayer.Models;
using LoanCalculator.DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator.BusinessLayer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _uow;

        public CustomerService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<CustomerDto> GetCustomerAndLoanDetails(string link)
        {
            var result = await _uow.Loans.GetCustomerLoanByGeneratedLinkAsync(link);

            return new CustomerDto
            {
                CustomerId = result.Customer.CustomerId,
                Title = result.Customer.Title,
                FirstName = result.Customer.FirstName,
                LastName = result.Customer.LastName,
                DateOfBirth = result.Customer.DateOfBirth,
                Mobile = result.Customer.Mobile,
                Email = result.Customer.Email,
                Term = result.TotalMonthTerms,
                ProductId = result.ProductId,
                AmountRequired = result.PrincipalAmount,
                MonthlyRepayment = result.MonthlyRepayment,
                TotalRepayment = result.TotalRepayment,
                EstablishmentFee = result.EstablishmentFee,
                TotalInterest = result.TotalInterest
            };
        }

        public async Task<string> AddCustomerThenGenerateLink(CustomerDto customer)
        {
            var res = await _uow.Customers.GetCustomerByFirstNameLastNameDateOfBirth(customer.FirstName, customer.LastName, customer.DateOfBirth);

            if (res != null)
                return res.Loans.FirstOrDefault().GeneratedLink.ToString();

            var customerEntity = new Customer();
            customerEntity.Title = customer.Title;
            customerEntity.FirstName = customer.FirstName;
            customerEntity.LastName = customer.LastName;
            customerEntity.DateOfBirth = customer.DateOfBirth;
            customerEntity.Mobile = customer.Mobile;
            customerEntity.Email = customer.Email;

            _uow.Customers.Add(customerEntity);

            var loanEntity = new Loan();
            loanEntity.CustomerId = customerEntity.CustomerId;
            loanEntity.GeneratedLink = Guid.NewGuid();
            loanEntity.TotalMonthTerms = customer.Term;
            loanEntity.PrincipalAmount = customer.AmountRequired;

            _uow.Loans.Add(loanEntity);

            await _uow.CompleteAsync();

            return loanEntity.GeneratedLink.ToString();
        }

        public async Task UpdateCustomerDetails(CustomerDto customer)
        {
            var customerEntity = await _uow.Customers.GetAsync(customer.CustomerId);
            var loanEntity = customerEntity.Loans.FirstOrDefault();

            customerEntity.Title = customer.Title;
            customerEntity.FirstName = customer.FirstName;
            customerEntity.LastName = customer.LastName;
            customerEntity.DateOfBirth = customer.DateOfBirth;
            customerEntity.Mobile = customer.Mobile;
            customerEntity.Email = customer.Email;

            loanEntity.ProductId = customer.ProductId;
            loanEntity.PrincipalAmount = customer.AmountRequired;
            loanEntity.TotalMonthTerms = customer.Term;

            await _uow.CompleteAsync();
        }
    }
}
