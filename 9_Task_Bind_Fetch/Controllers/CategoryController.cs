using _9_Task_Bind_Fetch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _9_Task_Bind_Fetch.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private Categery_Context db = new Categery_Context();

        // Load categories and subcategories
        public ActionResult Index()
        {
            List<Category> categories = db.Categories.ToList();

            return View(categories);
        }

        // Get products by subcategory via AJAX
        public JsonResult GetProductsBySubCategory(int subCategoryId)
        {
            var products = db.ProductDatas.Where(p => p.SubCategoryId == subCategoryId)
                                      .Select(p => new { p.Name, p.Price })
                                      .ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}