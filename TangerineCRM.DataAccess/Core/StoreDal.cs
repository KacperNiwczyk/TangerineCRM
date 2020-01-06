using System.Data.Entity;
using TangerineCRM.Core.DataAccess;
using TangerineCRM.DataAccess.Core.Contexts;
using TangerineCRM.DataAccess.Interfaces;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.DataAccess.Core
{
    public class StoreDal : EntityRepositoryBase<Store, DatabaseContext>, IStoreDal
    {
        public StoreDal(DbContext context) : base(context)
        {

        }
    }
}
