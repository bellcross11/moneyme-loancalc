using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator.DataAccessLayer.Model.Entities
{
    public class Loan
    {
        public int LoanId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int TotalMonthTerms { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal MonthlyRepayment { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal TotalRepayment { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
