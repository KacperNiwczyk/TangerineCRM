using System.Collections.Generic;
using System.Web.Mvc;
using TangerineCRM.Business;
using TangerineCRM.Business.Managers;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.DataAccess.Core.Contexts;
using TangerineCRM.Entities.Base;
using TangerineCRM.WebUI.Models;

namespace TangerineCRM.WebUI.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager;
        StoreManager storeManager;
        DatabaseContext context = new DatabaseContext();
        public ProductController()
        {
            productManager = new ProductManager(new ProductDal(context));
            storeManager = new StoreManager(new StoreDal(context));
        }

        // GET: Product
        public ActionResult Index()
        {

            productManager.Add(new Product() { ProductName = "Mandarynki", Store = new Store() { StoreName = "Biedronka" } });//TODO: Delete

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

            storeManager.GetAll()
                .ForEach(x => selectList.Add(new SelectListItem() { Text = $"{x.StoreId.ToString()} {x.StoreName}", Value = x.StoreId.ToString() }));

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
            var storeId = int.Parse(model.SelectedStoreID);
            p.Store = storeManager.GetBy(x => x.StoreId == storeId);
            productManager.Add(p);

            return RedirectToAction("Index", "Product");
        }
    }
}