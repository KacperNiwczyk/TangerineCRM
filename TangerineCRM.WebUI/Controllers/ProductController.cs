using System.Collections.Generic;
using System.Linq;
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
            var selectList = new List<SelectListItem>();

            productManager.GetAll()
                .Select(x => x.Store)
                .ToList()
                .ForEach(x => selectList.Add(new SelectListItem() { Text = x.StoreId.ToString(), Value = x.StoreId.ToString() }));

            var productModel = new ProductViewModel()
            {
                SelectList = selectList
            };

            return View(productModel);
        }

        [HttpPost]
        public ActionResult Add(ProductViewModel model)
        {
            var p = model.SingleProduct;
            p.Store = new Store();//Validation TODO 
            productManager.Add(p);

            return RedirectToAction("Index", "Product");
        }
    }
}