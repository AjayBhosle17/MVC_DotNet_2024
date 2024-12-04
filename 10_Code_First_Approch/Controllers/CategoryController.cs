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
    }
}