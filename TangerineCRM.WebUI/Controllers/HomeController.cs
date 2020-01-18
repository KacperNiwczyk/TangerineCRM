using System.Web.Mvc;
using TangerineCRM.Business.Managers;
using TangerineCRM.DataAccess.Core.Contexts;

namespace TangerineCRM.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        AppointmentManager appointmentManager;
        DatabaseContext context;

        public ActionResult Index()
        {
            return View();
        }
    }
}