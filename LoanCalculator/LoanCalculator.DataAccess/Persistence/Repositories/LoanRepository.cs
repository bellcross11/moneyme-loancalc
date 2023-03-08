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
    public class LoanRepository : Repository<LoanForm>, ILoanRepository
    {
        private readonly LoanDBContext _context;

        public LoanRepository(LoanDBContext context) 
            : base(context)
        {
            _context = context;
        }

        public async Task<LoanForm> GetLoanFormByPersonalDetailsAsync(string firstName, string lastName, DateTime dateOfBirth)
        {
            var loanForm = await base.GetAsync(
                i => i.FirstName == firstName && 
                i.LastName == i.LastName && 
                i.DateOfBirth == dateOfBirth
            );

            return loanForm;
        }

        public async Task<LoanForm> GetLoanFormByGeneratedLink(string link)
        {
            var loanForm = await base.GetAsync(i => i.GeneratedLink == link);

            return loanForm;
        }
    }
}
