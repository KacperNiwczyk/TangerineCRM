using TangerineCRM.Business.Interfaces;
using TangerineCRM.Core.Helpers.Enums;
using TangerineCRM.Entities.Base;
using TangerineCRM.DataAccess.Interfaces;
using System.Collections.Generic;

namespace TangerineCRM.Business.Managers
{
    public class ContractorManager : BaseManager<Contractor>, IContractorService
    {
        IContractorDal _contractorDal;
        public ContractorManager(IContractorDal contractorDal) : base (contractorDal)
        {
            _contractorDal = contractorDal;
        }

        public List<Contractor> GetAll()
        {
            throw new System.NotImplementedException();
        }

        protected override ValidationResult Validate(Contractor t)
        {
            return ValidationResult.SUCCESS;
        }
    }
}
