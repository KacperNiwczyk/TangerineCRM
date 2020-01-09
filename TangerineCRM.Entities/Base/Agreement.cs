using System;
using TangerineCRM.Core.Entities;

namespace TangerineCRM.Entities.Base
{
    public class Agreement : IEntity
    {
        public int AgreementId { get; set; }

        public virtual int ContractorID { get; set; }
        public virtual Contractor Contractor { get; set; }

        public virtual int SalesRepresentativeID { get; set; }
        public virtual SalesRepresentative SalesRepresentative { get; set; }
        public DateTime Date { get; set; }

        public decimal Value { get; set; }

        public bool IsSales { get; set; }

        public bool IsFinished { get; set; }
    }

}
