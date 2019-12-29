using TangerineCRM.Business.Interfaces;
using TangerineCRM.Core.Helpers.Enums;
using TangerineCRM.Entities.Base;
using TangerineCRM.DataAccess.Interfaces;

namespace TangerineCRM.Business.Managers
{
    public class ContractorManager : BaseManager<Contractor>, IContractorService
    {
        IContractorDal _contractorDal;
        public ContractorManager(IContractorDal contractorDal) : base (contractorDal)
        {
            _contractorDal = contractorDal;
        }

        protected override ValidationResult Validate(Contractor t)
        {
            return ValidationResult.SUCCESS;
        }
    }
}
