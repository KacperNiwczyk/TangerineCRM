using System.Collections.Generic;
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

        public IEnumerable<SelectListItem> SelectListResult { get; set; }

        public IEnumerable<SelectListItem> SelectListSalesRep { get; set; }

        public string SelectedResult { get; set; }

        public string SelectedContractorID { get; set; }

        public string SelectedType { get; set; }

        public string SelectedSalesRep { get; set; }


    }
}