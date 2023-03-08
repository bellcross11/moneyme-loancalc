using Excel.FinancialFunctions;
using LoanCalculator.DataAccess.Core.Common;
using LoanCalculator.DataAccess.Core.Domain;
using System;

namespace LoanCalculator.Application.Web.Helpers
{
    public class ComputeLoan : ILoanComputation
    {
        private readonly double _annualInterestRate = 0.10 / 12;

        public LoanForm GetTotalComputation(LoanForm entity)
        {
            decimal principalAmount = entity.PrincipalAmount + entity.EstablishmentFee;


            if (entity.ProductId == 1) // Interest Free
            {
                entity.MonthlyRepayment = Math.Abs((decimal)Financial.Pmt(0, entity.TotalMonthTerms, (double)principalAmount, 0, PaymentDue.EndOfPeriod));
                entity.TotalRepayment = this.GetTotalRepayment(entity.MonthlyRepayment, entity.TotalMonthTerms);
                
                // Expected to be 0, still get the output
                entity.TotalInterest = Math.Abs(this.GetTotalInterest(entity.TotalRepayment, principalAmount));
                
                return entity;
            }
            else
            {
                // Compute PMT with 10% interest
                entity.MonthlyRepayment = Math.Abs((decimal)Financial.Pmt(_annualInterestRate, entity.TotalMonthTerms, (double)principalAmount, 0, PaymentDue.EndOfPeriod));


                if (entity.ProductId == 2) // Has Interest with 2 months interest free
                {
                    decimal totalInterest = this.GetTotalInterest(this.GetTotalRepayment(entity.MonthlyRepayment, entity.TotalMonthTerms), principalAmount);
                    decimal monthlyInterest = totalInterest / entity.TotalMonthTerms;
                    decimal withoutTwoMonthsInterest = totalInterest - (monthlyInterest * 2);


                    entity.TotalInterest = withoutTwoMonthsInterest;
                    entity.TotalRepayment = principalAmount + entity.TotalInterest;
                    entity.MonthlyRepayment = entity.TotalRepayment / entity.TotalMonthTerms;

                    return entity;

                }
                else // Has Interest
                {
                    entity.TotalRepayment = this.GetTotalRepayment(entity.MonthlyRepayment, entity.TotalMonthTerms);
                    entity.TotalInterest = this.GetTotalInterest(entity.TotalRepayment, principalAmount);
                    
                    return entity;
                }
            }
        }

        private decimal GetTotalRepayment(decimal monthlyRepayment, decimal totalMonthTerms)
        {
            return monthlyRepayment * totalMonthTerms;
        }

        private decimal GetTotalInterest(decimal totalRepayment, decimal principalAmount)
        {
            return totalRepayment - principalAmount;
        }
    }
}