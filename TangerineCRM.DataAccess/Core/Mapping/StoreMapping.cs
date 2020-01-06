using System.Data.Entity.ModelConfiguration;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.DataAccess.Core.Mapping
{
    public class StoreMapping : EntityTypeConfiguration<Store>
    {
        public StoreMapping()
        {
            HasKey(x => x.StoreId);
        }
    }
}
