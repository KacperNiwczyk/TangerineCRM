using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangerineCRM.Core.Entities;

namespace TangerineCRM.Entities.Base
{
    public class SalesRepresentative : IEntity
    {
        public int SalesRepresentativeId { get; set; }
        public string Name { get; set; }
    }
}
