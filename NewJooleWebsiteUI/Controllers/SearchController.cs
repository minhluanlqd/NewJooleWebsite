using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewJooleWebsiteEntities;
using NewJooleWebsiteService;
using NewJooleWebsiteUI.Models;
using Newtonsoft.Json;

namespace NewJooleWebsiteUI.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public ActionResult Search()
        {
            List<tblCategory> cateList = new Service().GetCategories();
            ViewBag.CategoryName = new SelectList(cateList, "Category_ID", "Subcategory_Name");
            return View();
        }
        
        public ActionResult doSearch(string CategoryID, string SubcategoryName)
        {
            //TempData["Test2"] = CategoryID + SubcategoryName;
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

        /*public ActionResult GetSubcategoryList(string category)
        {
            List<tblSubcategory> subcateList = new Service().GetSubcategories(category);
            ViewBag.SubcategoryName = new SelectList(subcateList, "Subcategory_ID", "Subcategory_Name");
            return PartialView("DisplaySubcate");
        }

        submit = function () {
                var link = '@Url.Action("doSearch", "Search", new { SubcategoryName = "replace" })';
                link = link.replace("replace", $("#SubcategoryName").val());
                if ($("#SubcategoryName").val() != null) {
                    window.location.href = link;
                }
            }
        });
        */
    }
}