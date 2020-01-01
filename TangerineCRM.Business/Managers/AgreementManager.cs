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
    public class AgreementManager : BaseManager<Agreement>, IAgreementService
    {
        IAgreementDal _agreementDal;
        public AgreementManager(IAgreementDal agreementDal) : base (agreementDal) 
        {
            _agreementDal = agreementDal;
        }

        public List<Agreement> GetAll()
        {
            throw new NotImplementedException();
        }

        protected override ValidationResult Validate(Agreement t)
        {
            return ValidationResult.SUCCESS;
        }
    }
}
