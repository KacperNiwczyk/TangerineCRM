using System.Collections.Generic;
using System.Web.Mvc;
using TangerineCRM.Business.Managers;
using TangerineCRM.Core.Helpers;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.DataAccess.Core.Contexts;
using TangerineCRM.Entities.Base;
using TangerineCRM.WebUI.Models;

namespace TangerineCRM.WebUI.Controllers
{
    public class ContractorController : Controller
    {
        ContractorManager contractorManager;
        DatabaseContext context;

        public ContractorController()
        {
            context = new DatabaseContext();
            contractorManager = new ContractorManager(new ContractorDal(context));
        }
        // GET: Contractor
        public ActionResult Index()
        {
            contractorManager.Add(new Contractor() { FirstName = "Janusz", LastName = "Śliwiński", Discount = 7, IsContracted = true });

            var model = new ContractorViewModel()
            {
                ContractorList = contractorManager.GetAll()
            };
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new ContractorViewModel()
            {
                IsContractedList = GetIsContractedDropDown()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(ContractorViewModel model)
        {
            var contractor = ParseValuesFromModel(model);
            contractorManager.Add(contractor);

            return RedirectToAction("Index", "Contractor");
        }

        public ActionResult Delete(int id)
        {
            var contractor = contractorManager.GetBy(x => x.ContractorId == id);
            contractorManager.Delete(contractor);

            return RedirectToAction("Index", "Contractor");
        }

        public ActionResult Update(int id)
        {
            var contractor = contractorManager.GetBy(x => x.ContractorId == id);

            var model = ParseValuesToModel(contractor);

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(ContractorViewModel model)
        {
            var contractor = ParseValuesFromModel(model);
            contractorManager.Update(contractor);

            return RedirectToAction("Index", "Contractor");
        }

        private ContractorViewModel ParseValuesToModel(Contractor contractor)
        {
            var model = new ContractorViewModel()
            {
                SingleContractor = contractor,
                IsContractedList = GetIsContractedDropDown(),
                SelectedIsContractedValue = contractor.IsContracted.ToString()
            };

            return model;
        }

        private Contractor ParseValuesFromModel(ContractorViewModel model)
        {
            var contractor = model.SingleContractor;
            contractor.IsContracted = bool.Parse(model.SelectedIsContractedValue);

            return contractor;
        }

        public List<SelectListItem> GetIsContractedDropDown()
        {
            var list = new List<SelectListItem>();

            list.Add(new SelectListItem() { Text = true.GetPolishValue(), Value = true.ToString() });
            list.Add(new SelectListItem() { Text = false.GetPolishValue(), Value = false.ToString() });

            return list;
        }
    }
}