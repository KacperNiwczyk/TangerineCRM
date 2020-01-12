using System;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "To pole jest wymagane")]
        public DateTime Date { get; set; }

        public AppointmentType Type { get; set; }

        public Result Result { get; set; }
    }
}
