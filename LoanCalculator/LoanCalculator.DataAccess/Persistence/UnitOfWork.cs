using LoanCalculator.DataAccess.Core;
using LoanCalculator.DataAccess.Core.IRepositories;
using LoanCalculator.DataAccess.Persistence.EFContext;
using LoanCalculator.DataAccess.Persistence.Repositories;
using System.Threading.Tasks;

namespace LoanCalculator.DataAccess.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LoanDBContext _context;

        public UnitOfWork(LoanDBContext context)
        {
            _context = context;
            Loans = new LoanRepository(context);
        }


        public ILoanRepository Loans { get; private set; }

        public Task<int> CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
