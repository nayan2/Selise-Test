using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SeliseTest.Data.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(int pageSize, int pageIndex);
        Task<IEnumerable<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, bool>> func, int pageSize, int pageIndex, params Expression<Func<TEntity, TProperty>>[] includes) where TProperty : TEntity;
        Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> func);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> func, params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, bool>> func, Expression<Func<TEntity, TResult>> selector, params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> func, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, bool>> func, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, TResult>> selector, params Expression<Func<TEntity, object>>[] includes);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        Task<TEntity> EditAsync(TEntity entity);
        Task<IEnumerable<TEntity>> EditAsync(IEnumerable<TEntity> entityList);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> func);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> func);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> func, params Expression<Func<TEntity, object>>[] includes);
    }
}
