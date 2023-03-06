using LoanCalculator.DataAccess.Core.Domain;
using LoanCalculator.DataAccess.Core.IRepositories;
using LoanCalculator.DataAccess.Persistence.EFContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator.DataAccess.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly LoanDBContext _context;

        public CustomerRepository(LoanDBContext context) 
            : base(context)
        {
            _context = context;
        }

        public void Test() 
        {
            
        
        }
    }
}
