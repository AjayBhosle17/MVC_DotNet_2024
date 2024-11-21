
using _2_Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2_Razor.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {

            List<Category> list = new List<Category>()
            { 
            new Category() { Id =1 , Name="CateGory 1 ",Rating=5},
            new Category() { Id = 2, Name = "CateGory 2 ", Rating = 3 },
            new Category() { Id = 3, Name = "CateGory 3 ", Rating = 2 },
            new Category() { Id = 4, Name = "CateGory 4 ", Rating = 4 }

            };
            return View(list);
        }

        public ActionResult Create() { 
        
            return View();
        }

        public ActionResult CreateCategory() { 
        
            Category obj  = new Category() {Id =1 , Name="test-category1",Rating=4 };
            return View(obj);
        }
    }
}