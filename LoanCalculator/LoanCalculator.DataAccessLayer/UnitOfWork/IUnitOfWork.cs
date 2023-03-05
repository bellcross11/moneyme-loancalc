using LoanCalculator.DataAccessLayer.Repositories.IRepositories;
using System;

namespace LoanCalculator.DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        ILoanRepository Loans { get; }
        int Complete();
    }
}
