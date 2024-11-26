using _6_Scaffolding_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _6_Scaffolding_CRUD.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            List<Category> categories = new List<Category>();
            if (Session["Products"] == null)
            {
                categories = new List<Category>() {

                new Category(){Id = 1 ,Name = "Product 1" , Price= 200 },
                new Category(){Id = 2 ,Name = "Product 2" , Price= 400 },
                new Category(){Id = 3 ,Name = "Product 3" , Price= 500 }

            };
                Session["products"] = categories;
            }
            else
            {
                categories =(List<Category>) Session["Products"];
            }
            return View(categories);
        }

        /*Create*/

        [HttpGet]

        public ActionResult create() { 
        
            return View();
        }

/*Model Binder With Create*/

        [HttpPost]
        public ActionResult create(Category cat)
        {

            if (Session["products"] != null)
            {
                List<Category> categories = (List<Category>)Session["products"];

                categories.Add(cat);
                Session["products"] = categories;
                return RedirectToAction("Index");
            }
            else { 
            
                List<Category> categories = new List<Category>();
                categories.Add(cat);
                Session["products"] = categories;
                return RedirectToAction("Index");

            }

            return View();
        }


    }
}