using SeliseTest.Data.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SeliseTest.Data.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _dbContext;
        public Repository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> func)
        {
            return await _dbContext.Set<TEntity>().SingleAsync(func);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> func)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(func);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> func, params Expression<Func<TEntity, object>>[] includes)
        {
            return await includes.Aggregate(_dbContext.Set<TEntity>().AsQueryable(), (curr, next) => curr.Include(next), c => c.FirstOrDefaultAsync(func));
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> func)
        {
            return await _dbContext.Set<TEntity>().Where(func).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            return await includes.Aggregate(_dbContext.Set<TEntity>().AsQueryable(), (curr, next) => curr.Include(next)).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> func, params Expression<Func<TEntity, object>>[] includes)
        {
            return await includes.Aggregate(_dbContext.Set<TEntity>().AsQueryable(), (curr, next) => curr.Include(next), c => c.Where(func)).ToListAsync();
        }

        public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, bool>> func, Expression<Func<TEntity, TResult>> selector, params Expression<Func<TEntity, object>>[] includes)
        {
            return await includes.Aggregate(_dbContext.Set<TEntity>().AsQueryable(), (curr, next) => curr.Include(next), c => c.Where(func).Select(selector)).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> func, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, params Expression<Func<TEntity, object>>[] includes)
        {
            return await orderBy(includes.Aggregate(_dbContext.Set<TEntity>().AsQueryable(), (curr, next) => curr.Include(next), c => c.Where(func))).ToListAsync();
        }

        public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, bool>> func, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, TResult>> selector, params Expression<Func<TEntity, object>>[] includes)
        {
            return await orderBy(includes.Aggregate(_dbContext.Set<TEntity>().AsQueryable(), (curr, next) => curr.Include(next), c => c.Where(func))).Select(selector).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(int pageSize, int pageIndex)
        {
            return await _dbContext.Set<TEntity>().AsQueryable().Skip(pageSize * pageIndex - 1).Take(pageSize).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, bool>> func, int pageSize, int pageIndex, params Expression<Func<TEntity, TProperty>>[] includes) where TProperty : TEntity
        {
            return await includes.Aggregate(_dbContext.Set<TEntity>().AsQueryable(), (curr, next) => curr.Include(next), c => c.Skip(pageSize * pageIndex - 1).Take(pageSize).Where(func)).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task<TEntity> EditAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task<IEnumerable<TEntity>> EditAsync(IEnumerable<TEntity> entityList)
        {
            foreach (TEntity item in entityList)
            {
                _dbContext.Entry(item).State = EntityState.Modified;
            }
            return entityList;
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }
    }
}
