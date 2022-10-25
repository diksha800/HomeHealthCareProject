using HomeHealthCareMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeHealthCareMVC.Controllers
{
    public class HomeHealthCareController : Controller
    {
        // GET: HomeHealthCare
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
           
            return View();
        }
        public ActionResult AdminRegister()
        {
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }
    }
}