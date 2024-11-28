using _8_Database_Connectivity_With_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8_Database_Connectivity_With_CRUD.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        [HttpGet]
        public ActionResult Index()
        {
            List<Product> products = new List<Product>();

            // ado.net to read all Product from Product table
            string connectionString = "server=113.193.63.106,55010;database=Product;user id=b24;password=b24";

            //Sql Connection
            /*
                        SqlConnection connection = new SqlConnection();
                        connection.ConnectionString = connectionString;*/
            //above 2 line convert in 1 line

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open(); // connection is prepare

            return View(products);
        }
    }
}