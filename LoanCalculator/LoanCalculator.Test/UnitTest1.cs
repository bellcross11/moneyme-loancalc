using LoanCalculator.Application.Web.Helpers;
using LoanCalculator.DataAccess.Core.Common;
using LoanCalculator.DataAccess.Core.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoanCalculator.Test
{
    [TestClass]
    public class UnitTest1
    {
        private readonly ILoanComputation _compute;

        public UnitTest1()
        {
            _compute = new ComputeLoan();
        }

        [TestMethod]
        public void PMT_ProductA_MonthlyRepayment_TotalRepayment_TotalInterest()
        {
            // Arrange
            var arrange = new LoanForm {
                ProductId = 1,
                PrincipalAmount = 5000,
                EstablishmentFee = 300,
                TotalMonthTerms = 24
            };

            // Expected
            decimal MonthlyRepayment = 220.833333333333M;
            string MonthlyRepaymentStr = "220.83";

            decimal TotalRepayment = 5299.999999999992M;
            string TotalRepaymentStr = "5300";

            decimal TotalInterest = 0.000000000008M;
            string TotalInterestStr = "";


            // Act
            var computedForm = _compute.GetTotalComputation(arrange);


            // Output

            // Decimals
            Assert.AreEqual<decimal>(MonthlyRepayment, computedForm.MonthlyRepayment);
            Assert.AreEqual<decimal>(TotalRepayment, computedForm.TotalRepayment);
            Assert.AreEqual<decimal>(TotalInterest, computedForm.TotalInterest);

            // String Decimals
            Assert.AreEqual<string>(MonthlyRepaymentStr, computedForm.MonthlyRepayment.ToString("#.##"));
            Assert.AreEqual<string>(TotalRepaymentStr, computedForm.TotalRepayment.ToString("#.##"));
            Assert.AreEqual<string>(TotalInterestStr, computedForm.TotalInterest.ToString("#.##"));
        }

        [TestMethod]
        public void PMT_ProductB_MonthlyRepayment_TotalRepayment_TotalInterest()
        {
            // Arrange
            var arrange = new LoanForm
            {
                ProductId = 2,
                PrincipalAmount = 5000,
                EstablishmentFee = 300,
                TotalMonthTerms = 24
            };

            // Expected
            decimal MonthlyRepayment = 242.59021156754594444444444445M;
            string MonthlyRepaymentStr = "242.59";

            decimal TotalRepayment = 5822.1650776211026666666666667M;
            string TotalRepaymentStr = "5822.17";

            decimal TotalInterest = 522.16507762110266666666666667M;
            string TotalInterestStr = "522.17";


            // Act
            var computedForm = _compute.GetTotalComputation(arrange);


            // Output
            
            // Decimals
            Assert.AreEqual<decimal>(MonthlyRepayment, computedForm.MonthlyRepayment);
            Assert.AreEqual<decimal>(TotalRepayment, computedForm.TotalRepayment);
            Assert.AreEqual<decimal>(TotalInterest, computedForm.TotalInterest);

            // String Decimals
            Assert.AreEqual<string>(MonthlyRepaymentStr, computedForm.MonthlyRepayment.ToString("#.##"));
            Assert.AreEqual<string>(TotalRepaymentStr, computedForm.TotalRepayment.ToString("#.##"));
            Assert.AreEqual<string>(TotalInterestStr, computedForm.TotalInterest.ToString("#.##"));
        }

        [TestMethod]
        public void PMT_ProductC_MonthlyRepayment_TotalRepayment_TotalInterest()
        {
            // Arrange
            var arrange = new LoanForm
            {
                ProductId = 3,
                PrincipalAmount = 5000,
                EstablishmentFee = 300,
                TotalMonthTerms = 24
            };

            // Expected
            decimal MonthlyRepayment = 244.568109588838M;
            string MonthlyRepaymentStr = "244.57";

            decimal TotalRepayment = 5869.634630132112M;
            string TotalRepaymentStr = "5869.63";

            decimal TotalInterest = 569.634630132112M;
            string TotalInterestStr = "569.63";


            // Act
            var computedForm = _compute.GetTotalComputation(arrange);


            // Output

            // Decimals
            Assert.AreEqual<decimal>(MonthlyRepayment, computedForm.MonthlyRepayment);
            Assert.AreEqual<decimal>(TotalRepayment, computedForm.TotalRepayment);
            Assert.AreEqual<decimal>(TotalInterest, computedForm.TotalInterest);

            // String Decimals
            Assert.AreEqual<string>(MonthlyRepaymentStr, computedForm.MonthlyRepayment.ToString("#.##"));
            Assert.AreEqual<string>(TotalRepaymentStr, computedForm.TotalRepayment.ToString("#.##"));
            Assert.AreEqual<string>(TotalInterestStr, computedForm.TotalInterest.ToString("#.##"));
        }
    }
}
