using System.Web.Mvc;
using TangerineCRM.Business.Managers;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.DataAccess.Core.Contexts;
using TangerineCRM.WebUI.Models;

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
            var model = new SalesRepresentativeViewModel()
            {
                RepresentativesList = representativeManager.GetAll()
            };

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new SalesRepresentativeViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(SalesRepresentativeViewModel model)
        {
            var rep = model.SingleRepresentative;
            representativeManager.Add(rep);

            return RedirectToAction("Index", "SalesRepresentative");
        }

        public ActionResult Delete(int id)
        {
            var rep = representativeManager.GetBy(x => x.SalesRepresentativeId == id);
            representativeManager.Delete(rep);

            return RedirectToAction("Index", "SalesRepresentative");
        }

        public ActionResult Update(int id)
        {
            var rep = representativeManager.GetBy(x => x.SalesRepresentativeId == id);
            var model = new SalesRepresentativeViewModel()
            {
                SingleRepresentative = rep
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(SalesRepresentativeViewModel model)
        {
            var rep = model.SingleRepresentative;
            representativeManager.Update(rep);

            return RedirectToAction("Index", "SalesRepresentative");
        }
    }
}