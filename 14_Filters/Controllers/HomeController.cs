using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _14_Filters.Controllers
{
   /* [Authorize]*/
    public class HomeController : Controller
    {
        // GET: Home
        [AllowAnonymous]
        public ActionResult Index(string comment)
        {
            ViewBag.Comment = comment;  
            return View();
        }

        public ActionResult Index1()
        {
            return View();
        }
       // [RequireHttps]
        [AllowAnonymous]
        public ActionResult Index2()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult AddPost(string comment)
        {
            return RedirectToAction("Index", new {comment=comment});
        }

        [HttpGet]
        [ChildActionOnly]
        public PartialViewResult getPartialViewContent()
        {
            return PartialView("_PartialView");
        }
    }
}