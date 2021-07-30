using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewJooleWebsiteUI.Models
{
    public class ProductVM
    {
        public string productID { get; set; }
        public string subCategoryID { get; set; }
        public string productName { get; set; }
        public string productImage { get; set; }
        public string series { get; set; }
        public string model { get; set; }
        public int modelYear { get; set; }
        public string seriesInfo { get; set; }
        public string features { get; set; }

        public ProductVM(string pid, string scid, string pn, string pi, string s, string m, int y, string si, string f)
        {
            productID = pid;
            subCategoryID = scid;
            productName = pn;
            productImage = pi;
            series = s;
            model = m;
            modelYear = y;
            seriesInfo = si;
            features = f;
        }

        public ProductVM()
        {

        }
    }
}