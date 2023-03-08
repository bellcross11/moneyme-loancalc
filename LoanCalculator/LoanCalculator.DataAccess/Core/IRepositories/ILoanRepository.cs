using LoanCalculator.DataAccess.Core.Domain;
using System;
using System.Threading.Tasks;

namespace LoanCalculator.DataAccess.Core.IRepositories
{
    public interface ILoanRepository : IRepository<LoanForm>
    {
        Task<LoanForm> GetLoanFormByPersonalDetailsAsync(string firstName, string lastName, DateTime dateOfBirth);
        Task<LoanForm> GetLoanFormByGeneratedLink(string link);
    }
}
