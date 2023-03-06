using LoanCalculator.DataAccess.Core.IRepositories;
using System;
using System.Threading.Tasks;

namespace LoanCalculator.DataAccess.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        ILoanRepository Loans { get; }
        Task<int> CompleteAsync();
    }
}
