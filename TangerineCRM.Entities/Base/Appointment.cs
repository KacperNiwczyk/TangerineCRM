using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangerineCRM.Core.Entities;

namespace TangerineCRM.Entities.Base
{
    public class Appointment : IEntity
    {
        public int AppointmentId { get; set; }

        public int ContractorId { get; set; }

        public int SalesRepresentativeId { get; set; }

        public DateTime Date { get; set; }

        public string AppointmentType { get; set; }

        public bool Result { get; set; }
    }
}
