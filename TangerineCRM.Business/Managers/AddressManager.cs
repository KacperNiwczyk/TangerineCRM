using System.Collections.Generic;
using TangerineCRM.Business.Interfaces;
using TangerineCRM.Core.Helpers.Enums;
using TangerineCRM.DataAccess.Interfaces;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.Business.Managers
{
    public class AddressManager : BaseManager<Address>, IAddressService
    {
        IAddressDal _addresDal;
        public AddressManager(IAddressDal addressDal) : base(addressDal)
        {
            _addresDal = addressDal;
        }

        public List<Address> GetAll()
        {
            return _addresDal.GetList();
        }

        protected override ValidationResult Validate(Address t)
        {
            return ValidationResult.SUCCESS;
        }
    }
}
