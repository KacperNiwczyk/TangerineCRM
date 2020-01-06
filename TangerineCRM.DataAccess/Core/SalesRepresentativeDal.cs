using System.Data.Entity;
using TangerineCRM.Core.DataAccess;
using TangerineCRM.DataAccess.Core.Contexts;
using TangerineCRM.DataAccess.Interfaces;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.DataAccess.Core
{
    public class SalesRepresentativeDal : EntityRepositoryBase<SalesRepresentative, DatabaseContext>, ISalesRepresentativeDal
    {
        public SalesRepresentativeDal(DbContext context) : base(context)
        {

        }
    }
}
