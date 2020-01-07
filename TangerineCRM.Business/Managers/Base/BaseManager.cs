using System.Collections.Generic;
using TangerineCRM.Core.DataAccess;
using TangerineCRM.Core.Entities;
using TangerineCRM.Core.Helpers.Enums;

namespace TangerineCRM.Business.Managers
{
    public abstract class BaseManager<T> where T : class, IEntity, new()
    {
        IEntityRepository<T> _dal;

        public BaseManager(IEntityRepository<T> dal)
        {
            _dal = dal;
        }

        public void Add(T t)
        {
            var result = Validate(t);

            if (result == ValidationResult.SUCCESS)
            {
                _dal.Add(t);
            }
        }

        public void Delete(T t)
        {
            _dal.Delete(t);
        }

        public virtual void Update(T t)
        {
            _dal.Update(t);
        }

        protected abstract ValidationResult Validate(T t);

    }
}
