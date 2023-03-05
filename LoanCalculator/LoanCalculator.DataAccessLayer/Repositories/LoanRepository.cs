using LoanCalculator.DataAccessLayer.Models;
using LoanCalculator.DataAccessLayer.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator.DataAccessLayer.Repositories
{
    public class LoanRepository : GenericRepository<Loan>, ILoanRepository
    {
        public LoanRepository(DbContext context) : base(context)
        {

        }
    }
}
