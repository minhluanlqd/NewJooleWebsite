using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewJooleWebsiteUI.Models
{
    public class Category
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<string> SubCategoryName { get; set; }

    }
    public class SubCategory
    {
        public List<string> SubCategoryName { get; set; }
    }
}