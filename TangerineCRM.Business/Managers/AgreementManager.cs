using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public Agreement GetBy(Expression<Func<Agreement, bool>> filter)
        {
            return _agreementDal.Get(filter, x => x.Contractor, x => x.SalesRepresentative, x => x.Products);
        }
        public List<Agreement> GetAll()
        {
            return _agreementDal.GetList(null, x => x.SalesRepresentative, x => x.Contractor, x => x.Products);
        }

        protected override ValidationResult Validate(Agreement t)
        {
            return ValidationResult.SUCCESS;
        }
    }
}
