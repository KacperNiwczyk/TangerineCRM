using System.Collections.Generic;
using System.Web.Mvc;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.WebUI.Models
{
    public class AppointmentViewModel
    {
        public List<Appointment> AppointmentList { get; set; }

        public Appointment SingleAppointment { get; set; }

        public IEnumerable<SelectListItem> SelectList { get; set; }

        public string SelectedContractorID { get; set; }
    }
}