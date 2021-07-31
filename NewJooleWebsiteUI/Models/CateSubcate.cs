﻿using System.ComponentModel.DataAnnotations;

namespace NewJooleWebsiteUI.Models
{
    public class CateSubcate
    {
        [Required]
        [Display(Name = "Select Category")]
        public string CategoryID { get; set; }

        [Required]
        [Display(Name = "Select Subcategory")]
        public string SubcategoryID { get; set; }
    }
}