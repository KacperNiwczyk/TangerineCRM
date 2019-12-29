using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangerineCRM.Core.Entities;

namespace TangerineCRM.Business.Interfaces
{
    public interface IService<T> where T : class, IEntity, new()
    {
        List<T> GetAll();

        void Add(T t);

        void Update(T t);

        void Delete(T t);
    }
}
