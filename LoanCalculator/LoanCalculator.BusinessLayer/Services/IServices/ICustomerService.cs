using LoanCalculator.BusinessLayer.DataTransferObjects;
using System.Threading.Tasks;

namespace LoanCalculator.BusinessLayer.Services.IServices
{
    public interface ICustomerService
    {
        Task<string> AddCustomerThenGenerateLink(CustomerDto customer);

        Task<CustomerDto> GetCustomerAndLoanDetails(string link);

        Task UpdateCustomerDetails(CustomerDto customer);
    }
}
