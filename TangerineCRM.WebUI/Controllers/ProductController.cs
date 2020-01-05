using System.Web.Mvc;
using TangerineCRM.Business;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.Entities.Base;
using TangerineCRM.WebUI.Models;

namespace TangerineCRM.WebUI.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager;

        public ProductController()
        {
            productManager = new ProductManager(new ProductDal());
        }
        // GET: Product
        public ActionResult Index()
        {

            productManager.Add(new Product() { ProductName = "Mandarynki", Store = new Store() });

            var productModel = new ProductViewModel()
            {
                ProductList = productManager.GetAll()
            };

            return View(productModel);
        }

        public ActionResult Delete(int id)
        {
            Product p = productManager.GetBy(x => x.ProductId == id);
            productManager.Delete(p);

            return RedirectToAction("Index", "Product");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product p)
        {
            // TODO: Add validation
            productManager.Add(p);

            return RedirectToAction("Index", "Product");
        }
    }
}