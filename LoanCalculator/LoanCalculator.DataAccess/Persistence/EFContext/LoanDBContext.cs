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


        public virtual DbSet<LoanForm> Loans { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LoanConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
