using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4_Controler_to_VIew.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["Name"] = "Ajay Bhosle";

            ViewBag.email = "Ajaybhosle.comp@gmail.com";

            TempData["username"] = "Ajay_Bhosle_1718";

            Session["IsLogged"] = true;
            return View();

        }

        public ActionResult Index1() { 
        
            return View();
        }
    }
}