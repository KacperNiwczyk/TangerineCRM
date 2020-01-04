using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangerineCRM.Core.Entities;

namespace TangerineCRM.Entities.Base
{
    public class Agreement : IEntity
    {
        public int AgreementId { get; set; }
        
        public int ContractorId { get; set; }
        public virtual Contractor Contractor { get; set; }
        public int SalesRepresentativeId { get; set; }
        public virtual SalesRepresentative SalesRepresentative { get; set; }
        public DateTime Date { get; set; }

        public decimal Value { get; set; }

        public bool IsSales { get; set; }

        public bool IsFinished { get; set; }
    }

}
