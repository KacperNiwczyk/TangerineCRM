﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.DataAccess.Core.Mapping
{
    public class AddressMapping : EntityTypeConfiguration<Address>
    {
        public AddressMapping()
        {
            ToTable("Address");
            HasKey(x => x.AddressId);
        }
    }
}