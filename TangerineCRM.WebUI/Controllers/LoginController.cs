using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using TangerineCRM.Business.Managers;
using TangerineCRM.Core.Helpers.Enums;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.DataAccess.Core.Contexts;
using TangerineCRM.Entities.Base;
using TangerineCRM.WebUI.Models;

namespace TangerineCRM.WebUI.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {

        UserManager userManager;
        DatabaseContext context;

        public LoginController()
        {
            context = new DatabaseContext();
            userManager = new UserManager(new UserDal(context));
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var admin = userManager.GetBy(x => x.UserName.Equals("Admin") && x.Password.Equals("Admin"));

            if (admin == null)
            {
                userManager.Add(new User() { UserName = "Admin", Password = "Admin", UserType = UserType.ADMIN });
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Authorization(UserViewModel user)
        {
            var userDetails = userManager.GetAll().Where(x => x.UserName.Equals(user.SingleUser.UserName) && x.Password.Equals(user.SingleUser.Password)).FirstOrDefault();

            if (userDetails == null)
            {
                user.ErrorMessage = "Wrong login or password";
                return View("Index", user);
            }

            FormsAuthentication.SetAuthCookie(userDetails.UserName, true);
            Session["userId"] = userDetails.UserId;
            Session["userType"] = userDetails.UserType.ToString();
            Session["userName"] = userDetails.UserName;
            return RedirectToAction("Index", "Home");
        }
    }
}