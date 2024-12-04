using _9_EF_Crud_usingDB_First_Approch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _9_EF_Crud_usingDB_First_Approch.Controllers
{
    public class SubProductController : Controller
    {

        DatabaseConnection _db = new DatabaseConnection();
        // GET: SubProduct
        public ActionResult Index(int? product_Id)
        {
            List<SubProduct> subProducts = new List<SubProduct>();

            if (product_Id == null && product_Id <= 0)
            {
                subProducts = _db.SubProducts.ToList();
            }
            else { 
            
               // subProducts = _db.SubProducts.Where(p=>p.Product_Id== product_Id).ToList();
           
                // run by using stored procedure 
                subProducts = _db.GetProduct_Data(product_Id)?.ToList();
            }
            return View(subProducts);
        }
    }
}