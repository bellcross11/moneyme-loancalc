using LoanCalculator.BusinessLayer.Services.IServices;
using LoanCalculator.DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator.BusinessLayer.Services
{
    public class LoanService : ILoanService
    {
        private readonly IUnitOfWork _uow;

        public LoanService(IUnitOfWork uow)
        {
            _uow = uow;
        }
    }
}
