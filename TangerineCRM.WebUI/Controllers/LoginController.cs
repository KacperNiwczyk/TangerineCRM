using System.Linq;
using System.Web.Mvc;
using TangerineCRM.Business.Managers;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.WebUI.Models;

namespace TangerineCRM.WebUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorization(UserViewModel user)
        {
            var userManager = new UserManager(new UserDal());

            var userDetails = userManager.GetAll().Where(x => x.UserName.Equals(user.UserModel.UserName) && x.Password.Equals(user.UserModel.Password)).FirstOrDefault();

            if (userDetails == null)
            {
                user.ErrorMessage = "Wrong login or password";
                return View("Index", user);
            }

            Session["userId"] = user.UserModel.UserId;
            return RedirectToAction("Index", "Home");
        }
    }
}