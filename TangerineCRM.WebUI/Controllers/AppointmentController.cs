﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
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
    public class AppointmentController : Controller
    {
        AppointmentManager appointmentManager;
        ContractorManager contractorManager;
        SalesRepresentativeManager representativeManager;
        DatabaseContext context;

        public AppointmentController()
        {
            context = new DatabaseContext();
            appointmentManager = new AppointmentManager(new AppointmentDal(context));
            contractorManager = new ContractorManager(new ContractorDal(context));
            representativeManager = new SalesRepresentativeManager(new SalesRepresentativeDal(context));
        }

        // GET: Appointment
        public ActionResult Index()
        {

            var model = new AppointmentViewModel()
            {
                AppointmentList = appointmentManager.GetAll()
            };

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new AppointmentViewModel()
            {
                SelectListContractor = GetContractorDropDown(),
                SelectListSalesRep = GetSalesRepresentativeDropDown(),
                SelectListType = GetTypeDropDown(),
                SelectListResult = GetResultDropDown(),
                SelectEventList = GetEventDropDown()
            };

            return View(model);
        }

        private List<SelectListItem> GetEventDropDown()
        {
            var list = new List<SelectListItem>();

            Enum.GetValues(typeof(EventType)).Cast<EventType>()
                .ToList()
                .ForEach(x => list.Add(new SelectListItem()
                {
                    Text = x.GetStringValue(),
                    Value = x.ToString()
                }));

            return list;
        }

        [HttpPost]
        public ActionResult Add(AppointmentViewModel model)
        {
            var appointment = ParseValuesFromModel(model);

            appointmentManager.Add(appointment);

            return RedirectToAction("Index", "Appointment");
        }

        public ActionResult Delete(int id)
        {
            var a = appointmentManager.GetBy(x => x.AppointmentId == id);
            appointmentManager.Delete(a);

            return RedirectToAction("Index", "Appointment");
        }

        public ActionResult Update(int id)
        {
            var a = appointmentManager.GetBy(x => x.AppointmentId == id);

            var model = ParseValuesToModel(a);

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(AppointmentViewModel model)
        {
            var a = ParseValuesFromModel(model);

            appointmentManager.Update(a);

            return RedirectToAction("Index", "Appointment");
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

            Enum.GetValues(typeof(AppointmentType)).Cast<AppointmentType>()
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

        private Appointment ParseValuesFromModel(AppointmentViewModel model)
        {
            var appointment = new Appointment()
            {
                AppointmentId = model.SingleAppointment.AppointmentId,
                Contractor = GetContactor(model.SelectedContractorID, out int contratorId),
                ContractorID = contratorId,
                SalesRepresentative = GetRepsresentative(model.SelectedSalesRep, out int representativeId),
                SalesRepresentativeID = representativeId,
                Date = model.SingleAppointment.Date,
                Type = GetType(model.SelectedType),
                Result = GetResult(model.SelectedResult),
                Event = GetEventType(model.SelectedEvent),
                Note = model.SingleAppointment.Note
            };

            return appointment;
        }

        private Result GetResult(string selectedResult)
        {
            return (Result)Enum.Parse(typeof(Result), selectedResult);
        }

        private AppointmentType GetType(string selectedType)
        {
            return (AppointmentType)Enum.Parse(typeof(AppointmentType), selectedType);
        }

        private EventType GetEventType(string selectedEvent)
        {
            return (EventType)Enum.Parse(typeof(EventType), selectedEvent);
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

        private AppointmentViewModel ParseValuesToModel(Appointment a)
        {
            var model = new AppointmentViewModel()
            {
                SingleAppointment = a,
                SelectListContractor = GetContractorDropDown(),
                SelectedContractorID = a.ContractorID.ToString(),
                SelectListSalesRep = GetSalesRepresentativeDropDown(),
                SelectedSalesRep = a.SalesRepresentativeID.ToString(),
                SelectListType = GetTypeDropDown(),
                SelectedType = a.Type.ToString(),
                SelectListResult = GetResultDropDown(),
                SelectedResult = a.Result.ToString(),
                SelectEventList = GetEventDropDown(),
                SelectedEvent = a.Event.ToString()
            };

            return model;
        }


        public ActionResult UpdateResult(int id)
        {
            var a = appointmentManager.GetBy(x => x.AppointmentId == id);

            var model = new AppointmentViewModel()
            {
                SingleAppointment = a,
                SelectListResult = GetResultDropDown(),
                SelectedResult = a.Result.ToString()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateResult(AppointmentViewModel model)
        {
            var appointment = appointmentManager.GetBy(x => x.AppointmentId == model.SingleAppointment.AppointmentId);
            appointment.Result = GetResult(model.SelectedResult);

            appointmentManager.Update(appointment);

            return RedirectToAction("Index", "Home");
        }
    }
}