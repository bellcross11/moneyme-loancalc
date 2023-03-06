using System;
using System.Collections.Generic;

namespace LoanCalculator.DataAccess.Core.Domain
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}
