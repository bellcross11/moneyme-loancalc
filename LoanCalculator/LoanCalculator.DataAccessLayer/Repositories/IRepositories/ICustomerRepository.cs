using LoanCalculator.DataAccessLayer.Models;
using System;
using System.Threading.Tasks;

namespace LoanCalculator.DataAccessLayer.Repositories.IRepositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> GetCustomerByFirstNameLastNameDateOfBirth(string FirstName, string LastName, DateTime DateOfBirth);
    }
}
