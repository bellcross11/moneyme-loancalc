using LoanCalculator.DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LoanCalculator.DataAccessLayer.EFContext.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            this.HasKey(c => c.CustomerId).HasTableAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

            this.Property(c => c.Title).HasMaxLength(10).IsOptional();

            this.Property(c => c.FirstName).HasMaxLength(50).IsRequired();

            this.Property(c => c.LastName).HasMaxLength(50).IsRequired();

            this.Property(c => c.DateOfBirth).HasColumnType("datetime").IsRequired();

            this.Property(c => c.Mobile).HasMaxLength(13).IsOptional();

            this.Property(c => c.Email).HasMaxLength(80).IsOptional();

            // configure one-to-many relationship
            this.HasMany(c => c.Loans)
                .WithRequired(lo => lo.Customer)
                .HasForeignKey<int>(lo => lo.CustomerId);

            this.ToTable("tblCustomers");
        }
    }
}
