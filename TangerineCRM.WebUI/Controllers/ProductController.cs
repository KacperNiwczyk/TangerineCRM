using System.Web.Mvc;
using TangerineCRM.Business;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.WebUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var productManager = new ProductManager(new ProductDal());

            productManager.Add(new Product());

            return View();
        }
    }
}