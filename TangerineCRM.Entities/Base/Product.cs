using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangerineCRM.Core.Entities;

namespace TangerineCRM.Entities.Base
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int StoreID { get; set; }
        public Store Store { get; set; }

    }
}
