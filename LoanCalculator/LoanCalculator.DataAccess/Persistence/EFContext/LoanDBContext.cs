using LoanCalculator.DataAccess.Core.Domain;
using LoanCalculator.Infrastructure.EFContext.Configurations;
using System.Data.Entity;

namespace LoanCalculator.DataAccess.Persistence.EFContext
{
    public class LoanDBContext : DbContext
    {
        public LoanDBContext() : base("loanDBEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new LoanConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
