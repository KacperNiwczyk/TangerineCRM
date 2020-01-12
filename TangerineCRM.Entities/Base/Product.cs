using System.ComponentModel.DataAnnotations;
using TangerineCRM.Core.Entities;

namespace TangerineCRM.Entities.Base
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]

        public string ProductName { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        public decimal Price { get; set; }

        public virtual int StoreID { get; set; }
        public virtual Store Store { get; set; }
    }
}
