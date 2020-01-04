using System.Web.Mvc;

namespace TangerineCRM.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}