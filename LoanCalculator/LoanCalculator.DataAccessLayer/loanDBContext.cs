using LoanCalculator.DataAccessLayer.Model.Configuration;
using System.Data.Entity;

namespace LoanCalculator.DataAccessLayer
{
    public class loanDBContext : DbContext
    {
        public loanDBContext() : base("loanDBEntities")
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
