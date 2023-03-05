using LoanCalculator.DataAccessLayer.Models;
using System.Threading.Tasks;

namespace LoanCalculator.DataAccessLayer.Repositories.IRepositories
{
    public interface ILoanRepository : IGenericRepository<Loan>
    {
        Task<Loan> GetCustomerLoanByGeneratedLinkAsync(string generatedLink);
    }
}
