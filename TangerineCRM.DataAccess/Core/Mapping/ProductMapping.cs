
using System.Data.Entity.ModelConfiguration;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.DataAccess.Core.Mapping
{
    public class ProductMapping : EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            ToTable("Products");
            HasKey(x => x.ProductId);
            Property(x => x.ProductId).HasColumnName("ProductsID");
        }
    }
}
