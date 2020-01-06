using System.Data.Entity;
using TangerineCRM.Core.DataAccess;
using TangerineCRM.DataAccess.Core.Contexts;
using TangerineCRM.DataAccess.Interfaces;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.DataAccess.Core
{
    public class ContractorDal : EntityRepositoryBase<Contractor, DatabaseContext>, IContractorDal
    {
        public ContractorDal(DbContext context) : base(context)
        {

        }
    }
}
