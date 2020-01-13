using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.WebUI.Models
{
    public class AppointmentViewModel
    {
        public List<Appointment> AppointmentList { get; set; }

        public Appointment SingleAppointment { get; set; }

        public IEnumerable<SelectListItem> SelectListContractor { get; set; }

        public IEnumerable<SelectListItem> SelectListType { get; set; }

        public IEnumerable<SelectListItem> SelectEventList { get; set; }

        public IEnumerable<SelectListItem> SelectListResult { get; set; }

        public IEnumerable<SelectListItem> SelectListSalesRep { get; set; }

        public string SelectedResult { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public string SelectedContractorID { get; set; }

        public string SelectedType { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public string SelectedSalesRep { get; set; }

        public string SelectedEvent { get; set; }

    }
}