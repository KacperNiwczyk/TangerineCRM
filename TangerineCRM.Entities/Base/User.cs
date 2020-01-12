using System.ComponentModel.DataAnnotations;
using TangerineCRM.Core.Entities;
using TangerineCRM.Core.Helpers.Enums;

namespace TangerineCRM.Entities.Base
{
    public class User : IEntity
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }

        public UserType UserType { get; set; }
    }
}
