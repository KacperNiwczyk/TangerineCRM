using System;
using TangerineCRM.Core.Entities;

namespace TangerineCRM.Entities.Base
{
    public class Appointment : IEntity
    {
        public int AppointmentId { get; set; }

        public int ContractorId { get; set; }
        public virtual Contractor Contractor { get; set; }

        public int SalesRepresentativeId { get; set; }
        public virtual SalesRepresentative SalesRepresentative { get; set; }

        public DateTime Date { get; set; }

        public string AppointmentType { get; set; }

        public bool Result { get; set; }
    }
}
