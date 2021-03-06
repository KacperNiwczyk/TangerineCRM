﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.WebUI.Models
{
    public class StoreViewModel
    {
        public Store SingleStore { get; set; }

        public List<Store> StoreList { get; set; }

        public IEnumerable<SelectListItem> ContractorSelectList { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public string SelectedContractor { get; set; }

        public Dictionary<string, string> ErrorMessages { get; set; }
    }
}