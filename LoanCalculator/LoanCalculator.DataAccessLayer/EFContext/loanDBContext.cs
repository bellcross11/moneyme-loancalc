using LoanCalculator.DataAccessLayer.EFContext.Mapping;
using System.Data.Entity;

namespace LoanCalculator.DataAccessLayer.EFContext
{
    public class LoanDBContext : DbContext
    {
        public LoanDBContext() : base("loanDBEntities")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new LoanMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
