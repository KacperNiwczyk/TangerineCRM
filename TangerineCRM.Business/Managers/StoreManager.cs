using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangerineCRM.Business.Interfaces;
using TangerineCRM.Core.Helpers.Enums;
using TangerineCRM.DataAccess.Interfaces;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.Business.Managers
{
    public class StoreManager : BaseManager<Store>, IStoreService
    {
        IStoreDal _storeDal;
        public StoreManager(IStoreDal storeDal) : base (storeDal)
        {
            _storeDal = storeDal;
        }

        protected override ValidationResult Validate(Store t)
        {
            return ValidationResult.SUCCESS;
        }
    }
}
