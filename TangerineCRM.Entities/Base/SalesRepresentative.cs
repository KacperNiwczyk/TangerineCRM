using System.ComponentModel.DataAnnotations;
using TangerineCRM.Core.Entities;

namespace TangerineCRM.Entities.Base
{
    public class SalesRepresentative : IEntity
    {
        public int SalesRepresentativeId { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string LastName { get; set; }
    }
}
