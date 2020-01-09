using System.Collections.Generic;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.WebUI.Models
{
    public class AppointmentViewModel
    {
        public List<Appointment> AppointmentList { get; set; }

        public Appointment SingleAppointment { get; set; }
    }
}