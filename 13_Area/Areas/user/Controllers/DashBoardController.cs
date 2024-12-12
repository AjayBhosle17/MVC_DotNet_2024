using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _13_Area.Areas.user.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: user/DashBoard
        public ActionResult Index()
        {
            return View();
        }
    }
}