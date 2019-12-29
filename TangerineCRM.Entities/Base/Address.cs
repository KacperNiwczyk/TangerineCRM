using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangerineCRM.Core.Entities;

namespace TangerineCRM.Entities.Base
{
    public class Address : IEntity
    {
        public int AddressId { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Postcode { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }
    }
}
