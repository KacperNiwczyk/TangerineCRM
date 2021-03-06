﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.WebUI.Models
{
    public class ProductViewModel
    {
        public List<Product> ProductList { get; set; }
        public Product SingleProduct { get; set; }
        public IEnumerable<SelectListItem> SelectList { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public string SelectedStoreID { get; set; }

    }
}