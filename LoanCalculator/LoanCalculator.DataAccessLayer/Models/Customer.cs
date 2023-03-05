using System;
using System.Collections.Generic;

namespace LoanCalculator.DataAccessLayer.Models
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

        public virtual ICollection<Loan> Loans { get; set; }
    }
}
