using LoanCalculator.DataAccessLayer.Repositories.IRepositories;
using System;
using System.Threading.Tasks;

namespace LoanCalculator.DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        ILoanRepository Loans { get; }
        Task<int> CompleteAsync();
    }
}
