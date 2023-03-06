using LoanCalculator.DataAccess.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LoanCalculator.Infrastructure.EFContext.Configurations
{
    public class LoanConfiguration : EntityTypeConfiguration<Loan>
    {
        public LoanConfiguration()
        {
            this.HasKey(i => i.LoanId).HasTableAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

            this.Property(i => i.CustomerId).IsRequired();

            this.Property(i => i.ProductId).IsRequired();

            this.Property(i => i.TotalMonthTerms).IsRequired();

            this.Property(i => i.PrincipalAmount).HasPrecision(18, 2).IsRequired();

            this.Property(i => i.MonthlyRepayment).HasPrecision(18, 2).IsRequired();

            this.Property(i => i.TotalInterest).HasPrecision(18, 2).IsRequired();

            this.Property(i => i.TotalRepayment).HasPrecision(18, 2).IsRequired();

            this.Property(i => i.EstablishmentFee).HasPrecision(18, 2).IsRequired();

            this.Property(i => i.GeneratedLink).IsRequired();

            this.ToTable("tblLoans");
        }
    }
}
