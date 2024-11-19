using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_Introduction.Controllers
{
    /*[RoutePrefix("home")]*/
    public class ProductController : Controller
    {
        // GET: Product

        [Route("")]
        public string Index()
        {
            return "hii";
        }
    }
}