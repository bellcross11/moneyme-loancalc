using LoanCalculator.DataAccess.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LoanCalculator.Infrastructure.EFContext.Configurations
{
    public class LoanConfiguration : EntityTypeConfiguration<LoanForm>
    {
        public LoanConfiguration()
        {
            this.HasKey(i => i.LoanFormId).HasTableAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);
            
            this.Property(i => i.Title).IsOptional();
            
            this.Property(i => i.FirstName).IsRequired();

            this.Property(i => i.LastName).IsRequired();

            this.Property(i => i.DateOfBirth).HasColumnType("datetime").IsRequired();

            this.Property(i => i.Mobile).IsOptional();
            
            this.Property(i => i.Email).IsOptional();
            
            this.Property(i => i.GeneratedLink).IsRequired();


            this.Property(i => i.ProductId).IsRequired();

            this.Property(i => i.EstablishmentFee).HasPrecision(18, 2).IsRequired();

            this.Property(i => i.TotalMonthTerms).IsRequired();

            this.Property(i => i.PrincipalAmount).HasPrecision(18, 2).IsRequired();

            this.Property(i => i.MonthlyRepayment).HasPrecision(18, 2).IsRequired();

            this.Property(i => i.TotalRepayment).HasPrecision(18, 2).IsRequired();

            this.Property(i => i.TotalInterest).HasPrecision(18, 2).IsRequired();


            this.ToTable("tblLoanForms");
        }
    }
}
