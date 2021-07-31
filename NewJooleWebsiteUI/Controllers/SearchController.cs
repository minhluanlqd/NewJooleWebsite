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

        [HttpPost]
        public ActionResult Search(CateSubcate model)
        {
            if (!ModelState.IsValid) return View();
            Service temp = new Service();
            string subcateID = "";
            foreach (var cate in temp.GetCategories())
                foreach (var subcate in temp.GetSubcategories(cate.Category_ID))
                    if (subcate.Subcategory_Name == model.SubcategoryName)
                        subcateID = subcate.Subcategory_ID;

            List<tblProduct> productList = new Service().GetProducts();
            List<tblProduct> result = new List<tblProduct>();
            foreach (var product in productList)
                if (product.Subcategory_ID == subcateID)
                    result.Add(product);
            return RedirectToAction("ProductSummary", "Product", new { subcategoryID = subcateID, products = productList });
        }

        public ActionResult GetSubcategoryList(string category)
        {
            List<tblSubcategory> subcateList = new Service().GetSubcategories(category);
            ViewBag.SubcategoryName = new SelectList(subcateList, "Subcategory_ID", "Subcategory_Name");
            return PartialView("DisplaySubcate");
        }
        /*
        [HttpPost]
        public ActionResult Search(string category, string subcategory)
        {
            if (string.IsNullOrEmpty(term))
            {
                return RedirectToAction("Summary", "Product", new { searchString = term });

            }
            else
            {
                return RedirectToAction("Summary", "Product", new { searchString = term });
                //
                List<string> asdf = new List<string>();
                foreach (var temp in new Services.Service().GetSubCategories(Int32.Parse(Category)))
                {
                    asdf.Add(temp.SubCategory_Name);
                }
                

                if (asdf.Contains(SearchQuery))
                {
                    List<string> asdf = new List<string>();
                    foreach (var temp in new Services.Service().GetSubCategories(Int32.Parse(Category)))
                    {
                        asdf.Add(temp.SubCategory_Name);
                    }
                    //sub category
                    return RedirectToAction("Summary", "Product", SearchQuery);
                }
                else
                {
                    //search without subcategory
                    return RedirectToAction("Summary", "Product", SearchQuery);
                }

            }
            return RedirectToAction("Summary", "Product", SearchQuery);
            //
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
        */
    }
}