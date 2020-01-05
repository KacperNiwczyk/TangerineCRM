using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TangerineCRM.Core.Entities;
using TangerineCRM.DataAccess.Core.Contexts;

namespace TangerineCRM.Core.DataAccess
{
    public class EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }


        public TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] navigationProperies)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> dbQuery = context.Set<TEntity>();

                foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperies)
                    dbQuery = dbQuery.Include(navigationProperty);

                return dbQuery.AsNoTracking().Where(filter).FirstOrDefault();
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> dbQuery = context.Set<TEntity>();

                foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);

                return filter != null ? dbQuery.AsNoTracking().Where(filter).ToList() : dbQuery.AsNoTracking().ToList();   
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }
    }
}
