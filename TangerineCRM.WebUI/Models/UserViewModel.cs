using TangerineCRM.Entities.Base;

namespace TangerineCRM.WebUI.Models
{
    public class UserViewModel
    {
        public User UserModel { get; set; }

        public string ErrorMessage { get; set; }
    }
}