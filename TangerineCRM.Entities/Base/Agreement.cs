using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TangerineCRM.Core.Entities;
using TangerineCRM.Core.Helpers.Enums;

namespace TangerineCRM.Entities.Base
{
    public class Agreement : IEntity
    {
        public int AgreementId { get; set; }

        public virtual int ContractorID { get; set; }
        public virtual Contractor Contractor { get; set; }

        public virtual int SalesRepresentativeID { get; set; }
        public virtual SalesRepresentative SalesRepresentative { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public decimal Value { get; set; }

        public AgreementType Type { get; set; }

        public string City { get; set; }

        public List<Product> Products { get; set; }
    }

}
