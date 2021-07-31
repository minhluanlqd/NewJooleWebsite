using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewJooleWebsiteEntities;
using NewJooleWebsiteService;
using NewJooleWebsiteUI.Models;
using Newtonsoft.Json;

namespace JooleWebsite.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult ProductSummary(string subcategoryID)
        {
            List<tblProduct> productList = new Service().GetProducts();
            List<Products> result = new List<Products>();
            foreach (var tempProduct in productList)
                if (tempProduct.Subcategory_ID == subcategoryID)
                {
                    Products product = new Products(tempProduct.Product_ID,tempProduct.Subcategory_ID,tempProduct.Product_Name,tempProduct.Product_Image,tempProduct.Series,tempProduct.Model,tempProduct.Model_Year.Value,tempProduct.Series_Info,tempProduct.Features);
                    result.Add(product);
                }
            return View(result);
        }

    }
}