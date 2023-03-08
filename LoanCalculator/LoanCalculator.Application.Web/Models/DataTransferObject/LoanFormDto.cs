using System;

namespace LoanCalculator.Application.Web.Models.DataTransferObject
{
    public class LoanFormDto
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
        public int Term { get; set; }
        public decimal AmountRequired { get; set; }
        public decimal MonthlyRepayment { get; set; }
        public string MonthlyRepaymentStr { get; set; }
        public decimal TotalRepayment { get; set; }
        public string TotalRepaymentStr { get; set; }
        public decimal TotalInterest { get; set; }
        public string TotalInterestStr { get; set; }
    }
}