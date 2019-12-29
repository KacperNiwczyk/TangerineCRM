using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        IProductService _productService;

        public ProductController()
        {
            _productService = new ProductManager(new ProductDal());
        }
        // GET: Product
        public ActionResult Index()
        {
            var products = new ProductViewModel()
            {
                Products = _productService.GetAll()
            };

            return View(products);
        }
    }
}