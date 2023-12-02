using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using Torcidas.Infra.Data;
using Torcidas.Infra.Repositories.Interfaces;

namespace Torcidas.Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            _dbContext.ChangeTracker.Clear();

            IQueryable<TEntity> query = _dbSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public TEntity GetFirstOrDefault(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            _dbContext.ChangeTracker.Clear();

            IQueryable<TEntity> query = _dbSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (orderBy != null)
            {
                return orderBy(query).FirstOrDefault();
            }
            else
            {
                return query.FirstOrDefault();
            }
        }

        public TEntity GetById(int id) => _dbSet.Find(id);

        public TEntity Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                SaveChanges();
            }
        }

        public virtual int SaveChanges()
        {
            try
            {
                var result = _dbContext.SaveChanges();

                if (_dbContext.Database.CurrentTransaction != null)
                    _dbContext.Database.CommitTransaction();

                return result;
            }
            catch
            {
                _dbContext.Database.RollbackTransaction();
                throw;
            }
        }
    }
}
