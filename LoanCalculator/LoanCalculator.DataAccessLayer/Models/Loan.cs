using System;

namespace LoanCalculator.DataAccessLayer.Models
{
    public class Loan
    {
        public int LoanId { get; set; }
        public int ProductId { get; set; }
        public int TotalMonthTerms { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal MonthlyRepayment { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal TotalRepayment { get; set; }
        public decimal EstablishmentFee { get; set; }
        public Guid GeneratedLink { get; set; }        

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
