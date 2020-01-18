using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.WebUI.Models
{
    public class AgreementViewModel
    {
        public Agreement SingleAgreement { get; set; }

        public List<Agreement> AgreementList { get; set; }
        public IEnumerable<SelectListItem> SelectListContractor { get; set; }

        public IEnumerable<SelectListItem> SelectListSalesRep { get; set; }

        public IEnumerable<SelectListItem> SelectListType { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public string SelectedContractor { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public string SelectedSalesRep { get; set; }

        public string SelectedType { get; set; }

        public IEnumerable<SelectListItem> AvailableProducts { get; set; }

        public IEnumerable<SelectListItem> SelectedProducts { get; set; }

    }
}