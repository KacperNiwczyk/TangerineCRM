using System.Web.Mvc;
using TangerineCRM.Business;
using TangerineCRM.Business.Interfaces;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.Entities.Base;
using TangerineCRM.WebUI.Models;

namespace TangerineCRM.WebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductService productManager;

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
            productManager.Delete

            return View()
        }

        public Product Find(int id)
        {
            productManager.
        }
    }
}