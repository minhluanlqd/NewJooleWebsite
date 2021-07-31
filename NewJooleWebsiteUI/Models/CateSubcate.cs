using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NewJooleWebsiteUI.Models
{
    public class CateSubcate
    {
        [Required]
        [Display(Name = "Select Category")]
        public string CategoryName { get; set; }

        [Required]
        [Display(Name = "Select Subcategory")]
        public string SubcategoryName { get; set; }
    }
}