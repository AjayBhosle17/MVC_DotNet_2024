using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3_Types_Of_View.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index1()
        {
            return View();
        }

        public PartialViewResult Header()
        {
            return PartialView("_Header");
        }

        public ActionResult IndexLayout() { 
        
            return View();
        }

        public ActionResult IndexLayout1()
        {

            return View();
        }
    }
}