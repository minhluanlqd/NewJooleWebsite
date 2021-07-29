using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewJooleWebsiteService;
using NewJooleWebsiteUI.Models;

namespace NewJooleWebsiteUI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult LoginPage()
        {
            User temp = new User();
            return View(temp);
        }

        /*
         *
         * This method will retrive the login information from user and check if the login is accurate
         */
        [HttpPost]
        public ActionResult LoginPage(User temp)
        {
            Service service = new Service();
            if (ModelState.IsValid)
            {
                Console.WriteLine("Reach here");
                if (service.Authentication(temp.UserName, temp.Password))
                {
                    Session["userID"] = service.getSessionID(temp.UserName, temp.Password);
                    //return RedirectToAction("Summary", "Product");
                    Console.WriteLine("Reach here Success");
                    return RedirectToAction("ProductSummary", "Product");
                }
                else
                {
                    temp.LoginErrorMessage = "Incorrect username or password.";
                    Console.WriteLine("Reach here Error");
                    return View("LoginPage", temp);
                }
            }
            return View();
        }
    }
}