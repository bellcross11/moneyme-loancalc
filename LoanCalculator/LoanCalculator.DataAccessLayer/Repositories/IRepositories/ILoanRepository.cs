using LoanCalculator.DataAccessLayer.Models;
using System.Threading.Tasks;

namespace LoanCalculator.DataAccessLayer.Repositories.IRepositories
{
    public interface ILoanRepository : IRepository<Loan>
    {
        Task<Loan> GetCustomerLoanByGeneratedLinkAsync(string generatedLink);
    }
}
