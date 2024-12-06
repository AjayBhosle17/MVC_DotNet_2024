using _9_EF_Crud_usingDB_First_Approch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _9_EF_Crud_usingDB_First_Approch.Controllers
{
    public class ProductController : Controller
    {

        DatabaseConnection _db = new DatabaseConnection();
        // GET: Product
        public ActionResult Index(string search)
        {
            //fetching all categories from database using EF
            List<Product> products = new List<Product>();
            products = _db.Products.ToList();

            if (string.IsNullOrEmpty(search)) { 
            
                products=_db.Products.ToList();
            }
            else
            {
                products = _db.Products.Where(c => c.Name.Contains(search)).ToList();
            }

            return View(products);
        }

        [HttpGet]
        public ActionResult Create() { 
        
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                _db.Products.Add(product);
                _db.SaveChanges();      // to save it to database

            } catch (Exception) {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult Details(int id) {

            Product product = _db.Products.Find(id);

            if (product == null) {

                return ViewBag.name = "No Details Avialble";
            }
            return View(product);
        }
    }
}