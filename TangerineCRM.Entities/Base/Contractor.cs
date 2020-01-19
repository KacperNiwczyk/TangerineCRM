using System.ComponentModel.DataAnnotations;
using TangerineCRM.Core.Entities;

namespace TangerineCRM.Entities.Base
{
    public class Contractor : IEntity
    {
        public int ContractorId { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string LastName { get; set; }
        public int Discount { get; set; }
        public bool IsContracted { get; set; }
    }
}
