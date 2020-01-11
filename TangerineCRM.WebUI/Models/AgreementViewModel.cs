using System.Collections.Generic;
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

        public string SelectedContractor { get; set; }

        public string SelectedSalesRep { get; set; }

        public string SelectedType { get; set; }
    }
}