using _5_View_to_Controller.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace _5_View_to_Controller.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

      /*  public ActionResult Create(int productId)
        {
            ViewBag.productId = productId;
            return View();
        }*/

        /*[HttpPost]

        *//*  public ActionResult Index(string name , string price)
          {
              return RedirectToAction("Details", new { productId=0,Name=name,Price
              =price});
          }*//*
        public ActionResult Index(FormCollection form)
        {
            return RedirectToAction("Details", new
            {
                productId = 0,
                Name = form["name"],
                Price
            = form["price"]
            });
        }*/

        [HttpPost]
        /*public ActionResult Create(Product p)
        {*/
        public ActionResult Index(Product p)
            {

                /* ViewBag.Id = p.Id;
                 ViewBag.Price = p.Price;
                 ViewBag.ProdName = p.Name;*/


                return RedirectToAction("Details", new
            {
                ProductId = p.Id,
                Name = p.Name,
                Price= p.Price,

            });

        }

        [HttpGet]
        public ActionResult Details(int ProductId, string Name, int Price)
        {
            ViewBag.productId = ProductId;
            ViewBag.Name = Name;
            ViewBag.Price = Price;
            return View();
        }



    }  
}