using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangerineCRM.Core.DataAccess;
using TangerineCRM.DataAccess.Core.Contexts;
using TangerineCRM.DataAccess.Interfaces;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.DataAccess.Core
{
    public class StoreDal : EntityRepositoryBase<Store, DatabaseContext>, IStoreDal
    {
    }
}
