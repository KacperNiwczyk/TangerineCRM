using System.Web.Mvc;
using TangerineCRM.Business;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.Entities.Base;
using TangerineCRM.WebUI.Models;

namespace TangerineCRM.WebUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var productManager = new ProductManager(new ProductDal());

            productManager.Add(new Product() { ProductName = "Mandarynki", Store = new Store() });

            var productModel = new ProductViewModel()
            {
                ProductModel = productManager.GetAll()
            };

            return View(productModel);
        }
    }
}