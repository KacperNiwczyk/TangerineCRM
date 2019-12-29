using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangerineCRM.Core.Entities;

namespace TangerineCRM.Entities.Base
{
    public class Contractor : IEntity
    {
        public int ContractorId { get; set; }
        public bool IsSupplier { get; set; }
        public decimal IndividualPricePercentage { get; set; }
        public bool IsContracted { get; set; }
    }
}
