using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_22.Models;

namespace Lab_22.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult AddUser(User newUser)
        {   
            Lab22Entities DB = new Lab22Entities();

            DB.Users.Add(newUser);

            try
            {
                DB.SaveChanges();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Oops! Something odd just happened...";
                ViewBag.ErrorDetails = ex.StackTrace;
                return View("Error");
            }

            return RedirectToAction("Index");
        }

    }
}