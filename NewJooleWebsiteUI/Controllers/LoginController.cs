using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewJooleWebsiteUI.Models;
using NewJooleWebsiteService;


namespace NewJooleWebsiteUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult Login()
        {
            Login temp = new Login();
            return View(temp);
        }

        [HttpPost]
        public ActionResult Login(Login temp)
        {
            Service loginService = new Service();
            if (ModelState.IsValid)
            {

                if (loginService.confirm(temp.UserName, temp.Password))
                {
                    Session["userID"] = loginService.getID(temp.UserName, temp.Password);
                    return RedirectToAction("ProductSummary", "Product");
                }
                else
                {
                    temp.LoginErrorMessage = "Invalid log in credentials.";
                    return View("Login", temp);
                }
            }
            return View();
        }
        
    }
}