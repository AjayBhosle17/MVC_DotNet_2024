using _12_MetaData_WithDatabaseFirstApproch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _12_MetaData_WithDatabaseFirstApproch.Controllers
{
    public class CategoryController : Controller
    {
        CategoryDbContext _categoryDbContext=null;
        public CategoryController() { 
        
            _categoryDbContext = new CategoryDbContext();
        }
        // GET: Category
        [HttpGet]
        public ActionResult Index()
        {
            List<Category> categories = _categoryDbContext.Categories.ToList();

            return View(categories);
        }

        [HttpGet]
        public ActionResult Create() { 
        
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _categoryDbContext.Categories.Add(category);

                    _categoryDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}