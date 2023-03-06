using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LoanCalculator.DataAccess.Core.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
