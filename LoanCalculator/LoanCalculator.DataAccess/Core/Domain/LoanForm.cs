using System;

namespace LoanCalculator.DataAccess.Core.Domain
{
    public class LoanForm
    {
        public int LoanFormId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string GeneratedLink { get; set; }
        public int ProductId { get; set; }
        public decimal EstablishmentFee { get; set; }
        public int TotalMonthTerms { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal MonthlyRepayment { get; set; }
        public decimal TotalRepayment { get; set; }
        public decimal TotalInterest { get; set; }
    }
}
