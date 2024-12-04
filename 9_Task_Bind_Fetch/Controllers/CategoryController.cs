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
        private Categery_Context _db = new Categery_Context();


        [HttpGet]
        public ActionResult Index()
        {
            List<Category> categories = _db.Categories.ToList();

            return View(categories);
        }

        public JsonResult GetProductsBySubCategory(int subCategoryId)
        {
            var products = _db.ProductDatas.Where(p => p.SubCategoryId == subCategoryId)
                                      .Select(p => new { p.Name, p.Price })
                                      .ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}