using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewJooleWebsiteUI.Models
{
    public class Products
    {
        public string Product_ID { get; set; }
        public string Subcategory_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Image { get; set; }
        public string Series { get; set; }
        public string Features { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; internal set; }
        public string SeriesInfo { get; internal set; }
    }
}