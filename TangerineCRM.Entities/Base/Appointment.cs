using System;
using TangerineCRM.Core.Entities;
using TangerineCRM.Core.Helpers.Enums;

namespace TangerineCRM.Entities.Base
{
    public class Appointment : IEntity
    {
        public int AppointmentId { get; set; }

        public virtual int ContractorID { get; set; }
        public virtual Contractor Contractor { get; set; }

        public virtual int SalesRepresentativeID { get; set; }
        public virtual SalesRepresentative SalesRepresentative { get; set; }

        public DateTime Date { get; set; }

        public AppointmentType Type { get; set; }

        public Result Result { get; set; }
    }
}
