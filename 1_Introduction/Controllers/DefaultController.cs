using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_Introduction.Controllers
{
    [RoutePrefix("Default")]

    public class DefaultController : Controller
    {
        // GET: Default

        [Route("Ajju")]
        public ActionResult Index1()
        {
            return View();
        }

        [Route("Details/Ajju")]
        public ActionResult Group() {

            return View();
        }
    }
}