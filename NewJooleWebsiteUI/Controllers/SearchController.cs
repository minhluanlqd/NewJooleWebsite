using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewJooleWebsiteUI.Models;
using Newtonsoft.Json;
using NewJooleWebsiteService;

namespace NewJooleWebsiteUI.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        [HttpGet]
        public ActionResult Search(string value)
        {
            List<Category> listObj = new List<Category>();
            foreach (var tempCatego in new Service().getCategories())
            {

                Category tempObj = new Category();
                tempObj.CategoryID = tempCatego.Category_ID;
                tempObj.CategoryName = tempCatego.Subcategory_Name;
                listObj.Add(tempObj);
            }

            ViewBag.Category = new SelectList(listObj, "CategoryID", "CategoryName");


            if (value != null)
            {
                SubCategory tempSubCategory = new SubCategory();

                List<string> subCategoList = new List<string>();
                string val = value;
                foreach (var temp in new Service().GetSubCategories(val))
                {
                    subCategoList.Add(temp.Subcategory_Name);
                }
                tempSubCategory.SubCategoryName = subCategoList;
                ViewBag.subCategory = new SelectList(subCategoList);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Search(string term, string Category)
        {
            if (string.IsNullOrEmpty(term))
            {
                return RedirectToAction("ProductSummary", "Product", new { searchString = term });
            }
            else
            {
                return RedirectToAction("ProductSummary", "Product", new { searchString = term });
            }
        }


        public JsonResult Autocomplete(string term, string Category)
        {
            List<string> filteredItems = new List<string>();
            Service serv = new Service();
            if (Category == "")
            {

                var cha1k = JsonConvert.SerializeObject(filteredItems);

                return Json(cha1k, JsonRequestBehavior.AllowGet);
            }
            foreach (var temp in serv.GetSubCategories(Category))
            {
                filteredItems.Add(temp.Subcategory_Name);
            }
            filteredItems.Contains(term);
            List<string> filt = new List<string>();

            foreach (var vals in filteredItems)
            {
                string normal = vals.ToLower();
                if (normal.Contains(term.ToLower()))
                {
                    filt.Add(vals);
                }
            }

            var chak = JsonConvert.SerializeObject(filt);

            return Json(chak, JsonRequestBehavior.AllowGet);
        }
    }
}