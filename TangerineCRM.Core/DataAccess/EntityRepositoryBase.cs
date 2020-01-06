using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TangerineCRM.Core.Entities;

namespace TangerineCRM.Core.DataAccess
{
    public class EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {

        DbContext _context;
        public EntityRepositoryBase(DbContext context)
        {
            _context = context;
        }

        public TEntity Add(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
            return entity;
        }

        public void Delete(TEntity entity)
        {

            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] navigationProperies)
        {

            IQueryable<TEntity> dbQuery = _context.Set<TEntity>();

            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperies)
                dbQuery = dbQuery.Include(navigationProperty);

            return dbQuery.Where(filter).FirstOrDefault();
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] navigationProperties)
        {

            IQueryable<TEntity> dbQuery = _context.Set<TEntity>();

            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include(navigationProperty);

            return filter != null ? dbQuery.AsNoTracking().Where(filter).ToList() : dbQuery.AsNoTracking().ToList();

        }

        public TEntity Update(TEntity entity)
        {

            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
            return entity;

        }
    }
}
