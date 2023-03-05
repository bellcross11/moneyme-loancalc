using LoanCalculator.DataAccessLayer.Repositories;
using LoanCalculator.DataAccessLayer.Repositories.IRepositories;
using System.Data.Entity;
using System.Threading.Tasks;

namespace LoanCalculator.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            Loans = new LoanRepository(_context);
        }

        public ICustomerRepository Customers { get; private set; }

        public ILoanRepository Loans { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
