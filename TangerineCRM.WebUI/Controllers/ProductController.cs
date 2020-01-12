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
    [Authorize]
    public class ProductController : Controller
    {
        ProductManager productManager;
        StoreManager storeManager;
        DatabaseContext context;
        public ProductController()
        {
            context = new DatabaseContext();
            productManager = new ProductManager(new ProductDal(context));
            storeManager = new StoreManager(new StoreDal(context));
        }

        // GET: Product
        public ActionResult Index()
        {
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
            var productModel = new ProductViewModel()
            {
                SelectList = GetSelectList()
            };

            return View(productModel);
        }

        public ActionResult Update(int id)
        {
            Product p = productManager.GetBy(x => x.ProductId == id);

            var productModel = new ProductViewModel()
            {
                SingleProduct = p,
                SelectedStoreID = p.Store.StoreId.ToString(),
                SelectList = GetSelectList()
            };

            return View(productModel);
        }

        [HttpPost]
        public ActionResult Update(ProductViewModel model)
        {
            var p = model.SingleProduct;
            p.Store = GetStoreById(model.SelectedStoreID);
            p.StoreID = int.Parse(model.SelectedStoreID);
            productManager.Update(p);

            return RedirectToAction("Index", "Product");
        }

        [HttpPost]
        public ActionResult Add(ProductViewModel model)
        {
            var p = model.SingleProduct;
            p.Store = GetStoreById(model.SelectedStoreID);
            productManager.Add(p);

            return RedirectToAction("Index", "Product");
        }

        private List<SelectListItem> GetSelectList()
        {
            var selectList = new List<SelectListItem>();

            storeManager.GetAll()
                .ForEach(x => selectList.Add(new SelectListItem() { Text = $"{x.StoreId.ToString()} {x.StoreName} {x.Street} {x.City}", Value = x.StoreId.ToString() }));

            return selectList;
        }

        private Store GetStoreById(string storeId)
        {
            var Id = int.Parse(storeId);

            return storeManager.GetBy(x => x.StoreId == Id);
        }
    }
}