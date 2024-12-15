using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using _14_Filters.CustomFilter;

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
            throw new Exception("Custom Exception Thrown in Index1");
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

        /*[OutputCache (Duration =10)]*/

        [OutputCache(CacheProfile = "shortCache")]
        public ActionResult CacheDemo() {

            /*Thread.Sleep(3000);*/

            ViewBag.sleepTime=DateTime.Now;
            return View();
        }


        // handler error

        [HttpGet]
        /*[HandleError]*/

       /* [CustomErrorHandleAttribute]*/
        public ActionResult Logout() {

            int x = 10;
            int y = 0;
            int z = x/y;
            return View();
        }
    }
}