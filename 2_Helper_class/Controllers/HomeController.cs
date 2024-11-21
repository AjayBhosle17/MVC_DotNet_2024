using _2_Helper_class.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2_Helper_class.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Category> categories = new List<Category>()
            {
            new Category(){ Id = 1, Name = "category 1", Rating = 5},
            new Category(){ Id = 2, Name = "category 2", Rating = 3},
            new Category(){ Id = 3, Name = "category 3", Rating = 4},
            new Category(){ Id = 4, Name = "category 4", Rating = 4},
            new Category(){ Id = 5, Name = "category 5", Rating = 2}
            };
            return View("listing");
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}