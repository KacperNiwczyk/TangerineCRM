using System;
using System.Web.Mvc;
using TangerineCRM.Business.Managers;
using TangerineCRM.Core.Helpers.Enums;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.DataAccess.Core.Contexts;
using TangerineCRM.Entities.Base;
using TangerineCRM.WebUI.Models;

namespace TangerineCRM.WebUI.Controllers
{
    public class AppointmentController : Controller
    {
        AppointmentManager appointmentManager;
        ContractorManager contractorManager;
        SalesRepresentativeManager representativeManager;
        DatabaseContext context = new DatabaseContext();

        public AppointmentController()
        {
            appointmentManager = new AppointmentManager(new AppointmentDal(context));
            contractorManager = new ContractorManager(new ContractorDal(context));
            representativeManager = new SalesRepresentativeManager(new SalesRepresentativeDal(context));
        }

        // GET: Appointment
        public ActionResult Index()
        {
            appointmentManager.Add(new Appointment()
            {
                Contractor = new Contractor(),
                SalesRepresentative = new SalesRepresentative(),
                Date = DateTime.Now,
                Type = AppointmentType.INFO,
                Result = true
            });

            var model = new AppointmentViewModel()
            {
                AppointmentList = appointmentManager.GetAll()
            };

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }


    }
}