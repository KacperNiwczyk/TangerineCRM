using System.Web.Mvc;
using TangerineCRM.Business.Managers;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.DataAccess.Core.Contexts;

namespace TangerineCRM.WebUI.Controllers
{
    public class SalesRepresentativeController : Controller
    {
        SalesRepresentativeManager representativeManager;
        DatabaseContext context;

        public SalesRepresentativeController()
        {
            context = new DatabaseContext();
            representativeManager = new SalesRepresentativeManager(new SalesRepresentativeDal(context));
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}