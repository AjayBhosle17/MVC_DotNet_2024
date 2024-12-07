using _10_Code_First_Approch.Models;
using _10_Code_First_Approch.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _10_Code_First_Approch.Controllers
{
    public class CategoryController : Controller
    {
        CodeFirstDB _dbContext;

        public CategoryController() {

            _dbContext = new CodeFirstDB();
        }

        // GET: Category
        public ActionResult Index()
        {
            List<Category> categories = _dbContext.categories.ToList();
            return View(categories);
        }

        [HttpGet]

        public ActionResult Create() {

            return View();
        }

        [HttpPost]

        public ActionResult Create(Category category) {

            _dbContext.categories.Add(category);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult Details(int id) {

            Category category = _dbContext.categories.Find(id);

            return View(category);

        }

        [HttpGet]
        public ActionResult Delete(int? id) {

            Category category = _dbContext.categories.Find(id);

            return View(category);


        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {

            Category category = _dbContext.categories.Find(id);
            if (id == null)
            {

                return View(category);
            }
            else
            {

                _dbContext.categories.Remove(category);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

        }

        [HttpGet]

        public ActionResult Edit(int? id) {

            Category category = _dbContext.categories.Find(id);
            return View(category);
        }


        [HttpPost]
        public ActionResult Edit(Category category)
        {

            Category category1 = _dbContext.categories.Find(category.Id);

            if (category == null)
            {

                return View(category1);
            }
            else
            {

                category1.Name = category.Name;
                category1.Rating = category.Rating;


                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }


        }
    }


}