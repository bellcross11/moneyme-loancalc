using LoanCalculator.DataAccess.Core.IRepositories;
using System;
using System.Threading.Tasks;

namespace LoanCalculator.DataAccess.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ILoanRepository Loans { get; }
        Task<int> CompleteAsync();
    }
}
