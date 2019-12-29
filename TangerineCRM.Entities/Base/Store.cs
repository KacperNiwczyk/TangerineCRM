using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangerineCRM.Core.Entities;

namespace TangerineCRM.Entities.Base
{
    public class Store : IEntity
    {
        public int StoreId { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int ContractorId { get; set; }
        public Contractor Contractor { get; set; }
    }
}
