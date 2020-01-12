using System.ComponentModel.DataAnnotations;
using TangerineCRM.Core.Entities;

namespace TangerineCRM.Entities.Base
{
    public class Store : IEntity
    {
        public int StoreId { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string StoreName { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string City { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Street { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Postcode { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Telephone { get; set; }
        public virtual int ContractorID { get; set; }
        public virtual Contractor Contractor { get; set; }
    }
}
