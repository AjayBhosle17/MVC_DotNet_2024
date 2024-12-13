using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _13_Areas.Areas.user.Controllers
{
    public class DashboardController : Controller
    {
        // GET: user/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}