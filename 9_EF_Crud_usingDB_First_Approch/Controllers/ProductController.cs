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

        [HttpGet]

        public ActionResult Delete(int id) {

            Product product = _db.Products.Find(id);

            // 2 ways 
            /* 1. without post

                 if (product != null)
             {
                 _db.Products.Remove(product);
                 _db.SaveChanges();
                 return RedirectToAction("Index");
             }*/

            //  2. with post

            if (product == null) {

                ViewBag.name = "No Product Availble";
            }
            return View(product);

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Product product = _db.Products.Find(id);

                if (product == null)
                {
                    ViewBag.name = "No Product Availble";
                }

                _db.Products.Remove(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception) { 
            
                return RedirectToAction("Index");
            }

        }

        [HttpGet]

        public ActionResult Edit(int id) {

            Product product = _db.Products.Find(id);

            if (product == null)
            {

                ViewBag.name = "No Product Availble";
            }
            return View(product);

        }

        [HttpPost]

        public ActionResult Edit(Product product) { 
        
            Product p = _db.Products.Find(product.Id);
            if (p != null) { 
            
                p.Name = product.Name;
                p.Price = product.Price;

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return ViewBag.name = "No Product Availble";
            }

        }
        
    }
}