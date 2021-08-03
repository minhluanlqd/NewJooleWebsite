using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewJooleWebsiteEntities;
using NewJooleWebsiteService;
using Newtonsoft.Json;

namespace NewJooleWebsiteUI.Controllers
{
    public class ProductDetailsController : Controller
    {
        public ActionResult ProductDetails(string productID="1")
        {
            List<tblCategory> cateList = new Service().GetCategories();
            Session["CategoryName"] = new SelectList(cateList, "Category_ID", "Subcategory_Name");

            List<tblProduct> productList = new Service().GetProducts();
            List<tblProduct> result = new List<tblProduct>();
            foreach (var tempProduct in productList)
                if (tempProduct.Product_ID == productID)
                {
                    result.Add(tempProduct);
                    break;
                }
            return View(result);
        }

        public ActionResult doSearch(string CategoryID, string SubcategoryName)
        {
            Service temp = new Service();
            string Subcategory = "";

            if (!String.IsNullOrEmpty(CategoryID))
            {
                foreach (var subcate in temp.GetSubcategories(CategoryID))
                    if (subcate.Subcategory_Name.ToLower() == SubcategoryName.ToLower())
                    {
                        Subcategory = subcate.Subcategory_ID;
                        break;
                    }
            }
            else
            {
                bool found = false;
                foreach (var cate in temp.GetCategories())
                {
                    foreach (var subcate in temp.GetSubcategories(cate.Category_ID))
                        if (subcate.Subcategory_Name.ToLower() == SubcategoryName.ToLower())
                        {
                            Subcategory = subcate.Subcategory_ID;
                            found = true;
                            break;
                        }
                    if (found) break;
                }
            }
            return RedirectToAction("ProductSummary", "Product", new { subcategoryID = Subcategory });
        }

        public JsonResult Autocomplete(string CategoryID, string SubcategoryName)
        {
            Service temp = new Service();
            List<string> result = new List<string>();
            if (CategoryID != "")
            {
                foreach (var subcate in temp.GetSubcategories(CategoryID))
                    if (subcate.Subcategory_Name.ToLower().StartsWith(SubcategoryName.ToLower()))
                        result.Add(subcate.Subcategory_Name);
                return Json(JsonConvert.SerializeObject(result), JsonRequestBehavior.AllowGet);
            }

            foreach (var cate in temp.GetCategories())
                foreach (var subcate in temp.GetSubcategories(cate.Category_ID))
                    if (subcate.Subcategory_Name.ToLower().StartsWith(SubcategoryName.ToLower()))
                        result.Add(subcate.Subcategory_Name);
            return Json(JsonConvert.SerializeObject(result), JsonRequestBehavior.AllowGet);
        }
    }
}