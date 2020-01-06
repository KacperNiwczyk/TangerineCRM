using System.ComponentModel.DataAnnotations.Schema;
using TangerineCRM.Core.Entities;

namespace TangerineCRM.Entities.Base
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("Store_StoreId")]
        public virtual Store Store { get; set; }
    }
}
