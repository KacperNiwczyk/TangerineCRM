using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TangerineCRM.Core.Entities;

namespace TangerineCRM.DataAccess.Core.Contexts
{
    public static class ContextHelper
    {
        public static IQueryable<TEntity> IncludeMultiple<TEntity>(this DbSet<TEntity> dbSet, params Expression<Func<TEntity, object>>[] includes) where TEntity : class, IEntity, new()
        {
            IQueryable<TEntity> query = null;
            foreach (var include in includes)
            {
                query = dbSet.Include(include);
            }

            return query == null ? dbSet : query;
        }
    }
}
