using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_Introduction.Controllers
{
    [RoutePrefix("home")]
    public class ProductController : Controller
    {
        // GET: Product

        [Route("Details/{id}")]
        public string Index(int? id)
        {
            return $"my name is Ajay and Id is {id}";
        }

        // on browser =>  Product/MyData
        public ActionResult MyData() {

             return View("listing");


        }

        //Create Seaprate Folder in View and Pass Whole Path

        public ActionResult MyData2()
        {
            return View("~/MeraWala/my_file.cshtml");

        }
    }
}