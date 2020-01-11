using System.Web.Mvc;
using TangerineCRM.Business.Managers;
using TangerineCRM.DataAccess;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.DataAccess.Core.Contexts;
using TangerineCRM.WebUI.Models;

namespace TangerineCRM.WebUI.Controllers
{
    public class StoreController : Controller
    {
        StoreManager storeManager;
        AddressManager addressManager;
        ContractorManager contractorManager;
        DatabaseContext context;

        public StoreController()
        {
            context = new DatabaseContext();
            storeManager = new StoreManager(new StoreDal(context));
            addressManager = new AddressManager(new AddressDal(context));
            contractorManager = new ContractorManager(new ContractorDal(context));
        }

        public ActionResult Index()
        {
            var model = new StoreViewModel()
            {
                StoreList = storeManager.GetAll()
            };

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new StoreViewModel()
            {
                m
            }
        }
    }
}