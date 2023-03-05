using LoanCalculator.DataAccessLayer.Models;
using LoanCalculator.DataAccessLayer.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator.DataAccessLayer.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        {

        }

        public async Task<Customer> GetCustomerByFirstNameLastNameDateOfBirth(string FirstName, string LastName, DateTime DateOfBirth)
        {
            var res = await base.FirstOrDefaultAsync(i =>
                i.FirstName == FirstName &&
                i.LastName == LastName &&
                i.DateOfBirth == DateOfBirth
            );

            return res;
        }
    }
}
