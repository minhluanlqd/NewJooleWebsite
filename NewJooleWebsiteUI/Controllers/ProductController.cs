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
            List<tblCategory> cateList = new Service().GetCategories();
            Session["CategoryName"] = new SelectList(cateList, "Category_ID", "Subcategory_Name");

            List<tblProduct> productList = new Service().GetProducts();
            List<Products> result = new List<Products>();
            foreach (var tempProduct in productList)
                if (tempProduct.Subcategory_ID == subcategoryID)
                {
                    Products product = new Products(tempProduct.Product_ID, tempProduct.Subcategory_ID, tempProduct.Product_Name, tempProduct.Product_Image, tempProduct.Series, tempProduct.Model, tempProduct.Model_Year.Value, tempProduct.Series_Info, tempProduct.Features);
                    result.Add(product);
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

        public ActionResult filterProductSummary(int beginningYear = 1932, int endingYear = 2030)
        {
            List<tblProduct> productList = new Service().GetProducts();
            List<Products> result = new List<Products>();
            foreach (var tempProduct in productList)
                if (tempProduct.Model_Year.Value >= beginningYear && tempProduct.Model_Year.Value <= endingYear)
                {
                    Products product = new Products(tempProduct.Product_ID, tempProduct.Subcategory_ID, tempProduct.Product_Name, tempProduct.Product_Image, tempProduct.Series, tempProduct.Model, tempProduct.Model_Year.Value, tempProduct.Series_Info, tempProduct.Features);
                    result.Add(product);
                }

            ViewBag.BeginningYear = beginningYear;
            ViewBag.EndingYear = endingYear;
            return View("ProductSummary", result);
        }
    }
}
