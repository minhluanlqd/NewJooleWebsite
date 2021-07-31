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

        public Products(string pid, string scid, string pn, string pi, string s, string m, int y, string si, string f)
        {
            Product_ID = pid;
            Subcategory_ID = scid;
            Product_Name = pn;
            Product_Image = pi;
            Series = s;
            Model = m;
            ModelYear = y;
            SeriesInfo = si;
            Features = f;
        }
    }
}