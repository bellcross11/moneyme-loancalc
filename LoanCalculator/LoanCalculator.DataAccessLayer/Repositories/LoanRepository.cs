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
    public class LoanRepository : GenericRepository<Loan>, ILoanRepository
    {
        public LoanRepository(DbContext context) : base(context)
        {

        }

        public async Task<Loan> GetCustomerLoanByGeneratedLinkAsync(string generatedLink)
        {
            var guidLink = Guid.Parse(generatedLink);
            var query = await base.FirstOrDefaultAsync(i => i.GeneratedLink == guidLink);

            return query;
        }
    }
}
