using System.Collections.Generic;
using TangerineCRM.Business.Interfaces;
using TangerineCRM.Core.Helpers.Enums;
using TangerineCRM.DataAccess.Interfaces;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.Business.Managers
{
    public class SalesRepresentativeManager : BaseManager<SalesRepresentative>, ISalesRepresentativeService
    {
        ISalesRepresentativeDal _salesRepresentativeDal;
        public SalesRepresentativeManager(ISalesRepresentativeDal salesRepresentativeDal) : base(salesRepresentativeDal)
        {
            _salesRepresentativeDal = salesRepresentativeDal;
        }

        public List<SalesRepresentative> GetAll()
        {
            return _salesRepresentativeDal.GetList();
        }

        protected override ValidationResult Validate(SalesRepresentative t)
        {
            return ValidationResult.SUCCESS;
        }
    }
}
