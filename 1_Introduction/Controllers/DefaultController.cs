using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_Introduction.Controllers
{
    

    public class DefaultController : Controller
    {
        // GET: Default

       
        public string Index1()
        {
            return "hiii";
        }

        [Route("Details/Ajju")]
        public ActionResult Group() {

            return View("Index1");
        }
    }
}