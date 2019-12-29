using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangerineCRM.Core.DataAccess;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.DataAccess.Interfaces
{
    public interface IStoreDal : IEntityRepository<Store>
    {
    }
}
