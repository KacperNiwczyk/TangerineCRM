using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TangerineCRM.Business.Managers;
using TangerineCRM.Core.Helpers;
using TangerineCRM.Core.Helpers.Enums;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.DataAccess.Core.Contexts;
using TangerineCRM.WebUI.Models;

namespace TangerineCRM.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        AppointmentManager appointmentManager;
        DatabaseContext context;

        public HomeController()
        {
            context = new DatabaseContext();
            appointmentManager = new AppointmentManager(new AppointmentDal(context));
        }

        public ActionResult Index()
        {
            var model = new AppointmentViewModel()
            {
                AppointmentList = appointmentManager.GetAll().Where(x => x.Date <= DateTime.Now && x.Result == Result.INDEFINITE).ToList(),
                SelectListResult = GetResultDropDown()
            };

            return View(model);
        }

        private List<SelectListItem> GetResultDropDown()
        {
            var list = new List<SelectListItem>();

            Enum.GetValues(typeof(Result)).Cast<Result>()
               .ToList()
               .ForEach(x => list.Add(new SelectListItem()
               {
                   Text = x.GetStringValue(),
                   Value = x.ToString()
               }));

            return list;
        }
    }
}