using System.Collections.Generic;
using TangerineCRM.Business.Interfaces;
using TangerineCRM.Core.Helpers.Enums;
using TangerineCRM.DataAccess.Interfaces;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.Business.Managers
{
    public class ContractorManager : BaseManager<Contractor>, IContractorService
    {
        IContractorDal _contractorDal;
        public ContractorManager(IContractorDal contractorDal) : base(contractorDal)
        {
            _contractorDal = contractorDal;
        }

        public List<Contractor> GetAll()
        {
            return _contractorDal.GetList();
        }

        protected override ValidationResult Validate(Contractor t)
        {
            return ValidationResult.SUCCESS;
        }
    }
}
