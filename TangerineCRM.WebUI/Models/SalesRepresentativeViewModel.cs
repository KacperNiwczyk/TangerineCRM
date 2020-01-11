using System.Collections.Generic;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.WebUI.Models
{
    public class SalesRepresentativeViewModel
    {
        public SalesRepresentative SingleRepresentative { get; set; }
        public List<SalesRepresentative> RepresentativesList { get; set; }
    }
}