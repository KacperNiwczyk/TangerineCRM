﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TangerineCRM.Business;
using TangerineCRM.Business.Managers;
using TangerineCRM.Core.Helpers;
using TangerineCRM.Core.Helpers.Enums;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.DataAccess.Core.Contexts;
using TangerineCRM.Entities.Base;
using TangerineCRM.WebUI.Models;

namespace TangerineCRM.WebUI.Controllers
{
    [Authorize]
    public class AgreementController : Controller
    {
        AgreementManager agreementManager;
        ContractorManager contractorManager;
        SalesRepresentativeManager representativeManager;
        ProductManager productManager;
        DatabaseContext context;

        public AgreementController()
        {
            context = new DatabaseContext();
            productManager = new ProductManager(new ProductDal(context));
            agreementManager = new AgreementManager(new AgreementDal(context));
            contractorManager = new ContractorManager(new ContractorDal(context));
            representativeManager = new SalesRepresentativeManager(new SalesRepresentativeDal(context));
        }

        // GET: Agreement
        public ActionResult Index()
        {

            var model = new AgreementViewModel()
            {
                AgreementList = agreementManager.GetAll()
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new AgreementViewModel()
            {
                SelectListContractor = GetContractorDropDown(),
                SelectListSalesRep = GetSalesRepresentativeDropDown(),
                SelectListType = GetTypeDropDown(),
                AvailableProducts = GetAvailableProducts(),
                SelectedProducts = new List<string>()

            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AgreementViewModel model)
        {
            var agreement = ParselValuesFromModel(model);

            agreementManager.Add(agreement);

            return RedirectToAction("Index", "Agreement");
        }

        public ActionResult Delete(int id)
        {
            var agreement = agreementManager.GetBy(x => x.AgreementId == id);
            agreementManager.Delete(agreement);

            return RedirectToAction("Index", "Agreement");
        }

        public ActionResult Update(int id)
        {
            var agreement = agreementManager.GetBy(x => x.AgreementId == id);

            var model = ParseValuesToModel(agreement);

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(AgreementViewModel model)
        {
            var agreement = ParselValuesFromModel(model);

            agreementManager.Update(agreement);

            return RedirectToAction("Index", "Agreement");
        }

        private AgreementViewModel ParseValuesToModel(Agreement agreement)
        {
            var model = new AgreementViewModel()
            {
                SingleAgreement = agreement,
                SelectListContractor = GetContractorDropDown(),
                SelectedContractor = agreement.ContractorID.ToString(),
                SelectListSalesRep = GetSalesRepresentativeDropDown(),
                SelectedSalesRep = agreement.SalesRepresentativeID.ToString(),
                SelectListType = GetTypeDropDown(),
                SelectedType = agreement.Type.ToString()
            };

            return model;
        }

        private Agreement ParselValuesFromModel(AgreementViewModel model)
        {
            var products = GetProductsFromList(model.SelectedProducts);

            var agreement = new Agreement()
            {
                AgreementId = model.SingleAgreement.AgreementId,
                Contractor = GetContactor(model.SelectedContractor, out int contractorId),
                ContractorID = contractorId,
                SalesRepresentative = GetRepsresentative(model.SelectedSalesRep, out int representativeId),
                SalesRepresentativeID = representativeId,
                Type = GetType(model.SelectedType),
                Products = products,
                Date = model.SingleAgreement.Date,
                Value = GetProductsValue(products)
            };

            return agreement;
        }

        private List<Product> GetProductsFromList(IEnumerable<string> selectedProducts)
        {
            int cap = selectedProducts.ToList().Count;

            var products = new List<Product>(cap);

            foreach (var prod in selectedProducts)
            {
                products.Add(GetProduct(prod));
            }

            return products;
        }

        private decimal GetProductsValue(List<Product> products)
        {
            decimal sum = products.Sum(x => x.Price);

            return sum;
        }

        private Product GetProduct(string id)
        {
            var prodId = int.Parse(id);

            return productManager.GetBy(x => x.ProductId == prodId);
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

        private List<SelectListItem> GetTypeDropDown()
        {
            var list = new List<SelectListItem>();

            Enum.GetValues(typeof(AgreementType)).Cast<AgreementType>()
                .ToList()
                .ForEach(x => list.Add(new SelectListItem()
                {
                    Text = x.GetStringValue(),
                    Value = x.ToString()
                }));

            return list;
        }

        private List<SelectListItem> GetSalesRepresentativeDropDown()
        {
            var list = new List<SelectListItem>();

            representativeManager.GetAll()
                .ForEach(x => list.Add(new SelectListItem()
                {
                    Text = $"{x.SalesRepresentativeId} {x.FirstName} {x.LastName}",
                    Value = x.SalesRepresentativeId.ToString()

                }));

            return list;
        }

        private List<SelectListItem> GetAvailableProducts()
        {
            var productList = new List<SelectListItem>();

            var avProducts = productManager.GetAll();

            avProducts.ForEach(x => productList.Add(new SelectListItem()
            {
                Value = x.ProductId.ToString(),
                Text = $"{x.ProductId} {x.ProductName} {x.Price}zł"
            }));

            return productList;
        }

        private AgreementType GetType(string selectedType)
        {
            return (AgreementType)Enum.Parse(typeof(AgreementType), selectedType);
        }

        private SalesRepresentative GetRepsresentative(string id, out int representativeId)
        {
            representativeId = int.Parse(id);
            var representativeIdCopy = representativeId;

            return representativeManager.GetBy(x => x.SalesRepresentativeId == representativeIdCopy);
        }

        private Contractor GetContactor(string id, out int contractorId)
        {
            contractorId = int.Parse(id);
            var contractorIdCopy = contractorId;

            return contractorManager.GetBy(x => x.ContractorId == contractorIdCopy);
        }
    }
}