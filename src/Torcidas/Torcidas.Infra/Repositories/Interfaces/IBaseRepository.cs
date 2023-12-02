using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Torcidas.Infra.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true,
            bool ignoreQueryFilters = false
         );

        TEntity GetFirstOrDefault(
           Expression<Func<TEntity, bool>> predicate = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
           bool disableTracking = true,
           bool ignoreQueryFilters = false
        );
        TEntity GetById(int id);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int id);

        int SaveChanges();
    }

}
