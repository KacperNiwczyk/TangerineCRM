using System.Collections.Generic;
using System.Web.Mvc;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.WebUI.Models
{
    public class ContractorViewModel
    {
        public Contractor SingleContractor { get; set; }

        public List<Contractor> ContractorList { get; set; }

        public IEnumerable<SelectListItem> IsContractedList { get; set; }

        public string SelectedIsContractedValue { get; set; }
    }
}