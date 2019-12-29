using System.Data.Entity.ModelConfiguration;
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
