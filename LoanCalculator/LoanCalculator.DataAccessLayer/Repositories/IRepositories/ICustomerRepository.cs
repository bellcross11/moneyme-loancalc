using LoanCalculator.DataAccessLayer.Models;
using System;
using System.Threading.Tasks;

namespace LoanCalculator.DataAccessLayer.Repositories.IRepositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetCustomerByFirstNameLastNameDateOfBirth(string FirstName, string LastName, DateTime DateOfBirth);
    }
}
