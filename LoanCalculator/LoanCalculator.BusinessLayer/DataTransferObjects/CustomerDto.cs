using System;

namespace LoanCalculator.BusinessLayer.DataTransferObjects
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int ProductId { get; set; }
        public Guid GeneratedLink { get; set; }
        public decimal AmountRequired { get; set; }
        public int Term { get; set; }
        public decimal MonthlyRepayment { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal TotalRepayment { get; set; }
        public decimal EstablishmentFee { get; set; }
    }
}
