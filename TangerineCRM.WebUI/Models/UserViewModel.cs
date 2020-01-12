using System.Collections.Generic;
using System.Web.Mvc;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.WebUI.Models
{
    public class UserViewModel
    {
        public User SingleUser { get; set; }

        public List<User> UserList { get; set; }

        public string ErrorMessage { get; set; }

        public IEnumerable<SelectListItem> UserTypeList { get; set; }

        public string SelectedUserType { get; set; }
    }
}