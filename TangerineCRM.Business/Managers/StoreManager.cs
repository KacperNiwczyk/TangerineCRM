using System.Collections.Generic;
using TangerineCRM.Business.Interfaces;
using TangerineCRM.Core.Helpers.Enums;
using TangerineCRM.DataAccess.Interfaces;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.Business.Managers
{
    public class StoreManager : BaseManager<Store>, IStoreService
    {
        IStoreDal _storeDal;
        public StoreManager(IStoreDal storeDal) : base(storeDal)
        {
            _storeDal = storeDal;
        }

        public List<Store> GetAll()
        {
            return _storeDal.GetList(null, x => x.Address, x => x.Contractor);
        }

        protected override ValidationResult Validate(Store t)
        {
            return ValidationResult.SUCCESS;
        }
    }
}
