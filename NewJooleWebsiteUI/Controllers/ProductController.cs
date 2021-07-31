using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewJooleWebsiteService;
using NewJooleWebsiteUI.Models;
using Newtonsoft.Json;

namespace JooleWebsite.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult ProductSummary()
        {
            Service service = new Service();
            List<Products> valueList = new List<Products>();
            for(int i = 1; i < 6; i++)
            {
                Products value = new Products();
                var a = service.value(i.ToString());
                value.Product_ID = a.Product_ID;
                value.Subcategory_ID = a.Subcategory_ID;
                value.Product_Name = a.Product_Name;
                value.Model = a.Model;
                value.Series = a.Series;
                value.Product_Image = a.Product_Image;
                value.Features = a.Features;
                value.ModelYear = (int)a.Model_Year;
                value.SeriesInfo = a.Series_Info;

                valueList.Add(value);
            }
            
            return View(valueList);
        }
        
    }
}