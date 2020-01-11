using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TangerineCRM.Business.Managers;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.DataAccess.Core.Contexts;

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


            return View();
        }
    }
}