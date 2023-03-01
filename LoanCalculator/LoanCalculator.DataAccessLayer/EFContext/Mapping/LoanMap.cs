using LoanCalculator.DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LoanCalculator.DataAccessLayer.EFContext.Mapping
{
    public class LoanMap : EntityTypeConfiguration<Loan>
    {
        public LoanMap()
        {
            this.HasKey(i => i.LoanId).HasTableAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

            this.Property(i => i.CustomerId).IsRequired();

            this.Property(i => i.ProductId).IsRequired();

            this.Property(i => i.TotalMonthTerms).IsRequired();

            this.Property(i => i.PrincipalAmount).HasPrecision(18, 2).IsRequired();

            this.Property(i => i.MonthlyRepayment).HasPrecision(18, 2).IsRequired();

            this.Property(i => i.TotalInterest).HasPrecision(18, 2).IsRequired();

            this.Property(i => i.TotalRepayment).HasPrecision(18, 2).IsRequired();

            this.Property(i => i.DateAdded).HasColumnType("datetime").IsRequired();

            this.ToTable("tblLoans");
        }
    }
}
