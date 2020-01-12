using System.Collections.Generic;
using System.Web.Mvc;
using TangerineCRM.Business.Managers;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.DataAccess.Core.Contexts;
using TangerineCRM.Entities.Base;
using TangerineCRM.WebUI.Models;

namespace TangerineCRM.WebUI.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {
        StoreManager storeManager;
        ContractorManager contractorManager;
        DatabaseContext context;

        public StoreController()
        {
            context = new DatabaseContext();
            storeManager = new StoreManager(new StoreDal(context));
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

        [Authorize]
        public ActionResult Create()
        {
            var model = new StoreViewModel()
            {
                ContractorSelectList = GetContractorDropDown()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(StoreViewModel model)
        {
            var store = ParseValuesFromModel(model);

            storeManager.Add(store);

            return RedirectToAction("Index", "Store");
        }

        public ActionResult Delete(int id)
        {
            var store = storeManager.GetBy(x => x.StoreId == id);
            storeManager.Delete(store);

            return RedirectToAction("Index", "Store");
        }

        public ActionResult Update(int id)
        {
            var store = storeManager.GetBy(x => x.StoreId == id);

            var model = ParseValuesToModel(store);

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(StoreViewModel model)
        {
            var store = ParseValuesFromModel(model);
            storeManager.Update(store);

            return RedirectToAction("Index", "Store");
        }

        private StoreViewModel ParseValuesToModel(Store store)
        {
            var model = new StoreViewModel()
            {
                SingleStore = store,
                ContractorSelectList = GetContractorDropDown(),
                SelectedContractor = store.ContractorID.ToString()
            };

            return model;
        }

        private Store ParseValuesFromModel(StoreViewModel model)
        {
            var store = model.SingleStore;
            store.Contractor = GetContactor(model.SelectedContractor, out int contractorId);
            store.ContractorID = contractorId;

            return store;
        }

        private List<SelectListItem> GetContractorDropDown()
        {
            var list = new List<SelectListItem>();

            contractorManager.GetAll()
                .ForEach(x => list.Add(new SelectListItem()
                {
                    Text = $"{x.ContractorId} {x.FirstName} {x.LastName}",
                    Value = x.ContractorId.ToString()
                }));

            return list;
        }

        private Contractor GetContactor(string id, out int contractorId)
        {
            contractorId = int.Parse(id);
            var contractorIdCopy = contractorId;

            return contractorManager.GetBy(x => x.ContractorId == contractorIdCopy);
        }
    }
}