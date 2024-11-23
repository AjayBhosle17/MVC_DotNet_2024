using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5_View_to_Controller.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int productId, string Name , int Price)
        {
            ViewBag.productId = productId;
            return View();
        }
    }  
}