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

        /*Details*/

        [HttpGet]

        public ActionResult Details(int id)
        {
            if (Session["products"] != null) {

                List<Category> obj = (List<Category>)Session["products"];

                Category obj1 = obj.FirstOrDefault(model=>model.Id==id);

                return View(obj1);
            }
            return RedirectToAction("Index");
        }


        /*Edit*/

        [HttpGet]
        public ActionResult Edit(int id) {

            if (Session["products"] != null) {

                List<Category> obj = (List<Category>)Session["products"];
                Category obj1 = obj.FirstOrDefault(x => x.Id == id);
                return View(obj1);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Category cat) {

            if (Session["products"] != null) {

                List<Category> obj = (List<Category>)Session["products"];

                foreach (var item in obj) {

                    if (item.Id == cat.Id) { 
                    
                        item.Name=cat.Name;
                        item.Price=cat.Price;
                      

                        break;
                    }
                }
                Session["products"] = obj;

                return RedirectToAction("Index");

            }
            List<Category> obj1 = (List<Category>)Session["products"];
            Category obj2 = obj1.FirstOrDefault(x => x.Id == cat.Id);
            return View(obj2);
        }

        /*Delete*/

        [HttpGet]
        public ActionResult Delete(int id) {

            if (Session["products"] != null) {

                List<Category> obj = (List<Category>)Session["products"];

                Category obj1 = obj.FirstOrDefault(x => x.Id == id);
                obj.Remove(obj1);

                Session["products"]=obj;
                return RedirectToAction("Index");
            }

            List<Category> obj2 = (List<Category>)Session["products"];
            Category obj3= obj2.FirstOrDefault(x => x.Id == id);
            return View(obj3);
        }
       
    }
}