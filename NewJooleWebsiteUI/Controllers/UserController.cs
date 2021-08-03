using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewJooleWebsiteService;
using NewJooleWebsiteUI.Models;
using NewJooleWebsiteUI.user.dal;

namespace NewJooleWebsiteUI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult LoginPage()
        {
            if (Session["username"] != null && Session["password"] != null)
            {
                return RedirectToAction("Search", "Search");
            }
            return View();
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
                    Session["username"] = temp.UserName;
                    Session["password"] = temp.Password;
                    //return RedirectToAction("Summary", "Product");
                    Console.WriteLine("Reach here Success");
                    return RedirectToAction("Search", "Search");
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

        public ActionResult SignUpPopup()
        {
            return PartialView("SignUpPopup");
        }

        
        //submit on the sign up screen
        public ActionResult signUpSubmit(User temp)
        {
            //Service service = new Service();

            if (ModelState.IsValid)
            {
                //confirms the passwords match
                if (temp.Password != (temp.ConfirmPassword))
                {
                    temp.LoginErrorMessage = "Passwords does not match.";
                    return View("SignUpPopup", temp);
                }
                //write to database if all con
                else
                {
                    userDAL dal = new userDAL();
                    dal.Users.Add(temp);
                    dal.SaveChanges();
                    //service.addUser(temp);
                    return RedirectToAction("LoginPage");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("LoginPage");
        }
    }
}