using LoanCalculator.DataAccess.Core.Domain;

namespace LoanCalculator.DataAccess.Core.Common
{
    public interface ILoanComputation
    {
        LoanForm GetTotalComputation(LoanForm entity);
    }
}
