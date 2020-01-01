using System.Collections.Generic;
using TangerineCRM.Business.Interfaces;
using TangerineCRM.Core.Helpers.Enums;
using TangerineCRM.DataAccess.Interfaces;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.Business.Managers
{
    public class AgreementManager : BaseManager<Agreement>, IAgreementService
    {
        IAgreementDal _agreementDal;
        public AgreementManager(IAgreementDal agreementDal) : base(agreementDal)
        {
            _agreementDal = agreementDal;
        }

        public List<Agreement> GetAll()
        {
            return _agreementDal.GetList(null, x => x.SalesRepresentative, x => x.Contractor);
        }

        protected override ValidationResult Validate(Agreement t)
        {
            return ValidationResult.SUCCESS;
        }
    }
}
