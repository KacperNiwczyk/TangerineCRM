using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TangerineCRM.Business.Interfaces;
using TangerineCRM.Core.Helpers.Enums;
using TangerineCRM.DataAccess.Interfaces;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.Business.Managers
{
    public class AppointmentManager : BaseManager<Appointment>, IAppointmentService
    {
        IAppointmentDal _appointmentDal;
        public AppointmentManager(IAppointmentDal appointmentDal) : base(appointmentDal)
        {
            _appointmentDal = appointmentDal;
        }

        public Appointment GetBy(Expression<Func<Appointment, bool>> filter)
        {
            return _appointmentDal.Get(filter, x => x.Contractor, x => x.SalesRepresentative);
        }
        public List<Appointment> GetAll()
        {
            return _appointmentDal.GetList(null, x => x.Contractor, x => x.SalesRepresentative);
        }

        protected override ValidationResult Validate(Appointment t)
        {
            return ValidationResult.SUCCESS;
        }
    }
}
