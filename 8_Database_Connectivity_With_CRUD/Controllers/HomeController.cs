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
            //string connectionString = "server=113.193.63.106,55010;database=B24ADONETDB;user id=b24;password=b24";
            string connectionString = "server=DESKTOP-IBP9IN1\\SQLEXPRESS;database=MVCDB;integrated security=true";


            //Sql Connection
            /*
                        SqlConnection connection = new SqlConnection();
                        connection.ConnectionString = connectionString;*/
            //above 2 line convert in 1 line

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open(); // connection is prepare


                string query = "select * from Product";  // Query Prepare
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();  // command Executed

                if (reader != null)
                {

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Product product = new Product()
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Price = (int)reader["Price"]
                            };
                            products.Add(product);
                        }
                    }

                }
            }
            catch
            {
                return View(products);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return View(products);


        }


        [HttpGet]
        public ActionResult Details(int id) {

            Product products = null;

            // ado.net to read all Product from Product table
            string connectionString = "server=DESKTOP-IBP9IN1\\SQLEXPRESS;database=MVCDB;integrated security=true";

            //Sql Connection
            /*
                        SqlConnection connection = new SqlConnection();
                        connection.ConnectionString = connectionString;*/
            //above 2 line convert in 1 line

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open(); // connection is prepare


                string query = $"select * from Product where Id={id}";  // Query Prepare
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();  // command Executed

                if (reader != null)
                {

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            products = new Product()
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Price = (int)reader["Price"]
                            };
                        }
                    }

                }
            }
            catch
            {
                return View(products);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return View(products);
          
        }

        [HttpGet]

        public ActionResult Edit(int id) {

            Product product = null;

            string connectionString = "server=DESKTOP-IBP9IN1\\SQLEXPRESS;database=MVCDB;integrated security=true";

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = $"select * from Product where Id = {id}";

                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {

                    while (reader.Read())
                    {
                        product = new Product()
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Price = (int)reader["Price"]
                        };
                        break;
                    }
                }
            }
            catch (Exception ex)
            {

                return View(product);
                //ViewBag.ErrorMessage = "An error occurred: " + ex.Message;

            }
            finally {

                if (connection != null)
                {
                    connection.Close();
                }
            }
            return View(product);
        }


        [HttpPost]
        public ActionResult Edit(Product product)
        {
            // Connection string to the database
            string connectionString = "server=DESKTOP-IBP9IN1\\SQLEXPRESS;database=MVCDB;integrated security=true";

            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);

                string query = $"update Product set Name='{product.Name}', Price={product.Price} where Id ={product.Id}";

                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                int numberOfRowsAffected=cmd.ExecuteNonQuery();
                


                if (numberOfRowsAffected > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Create Failed";
                    return View(product);
                }
            }
            catch (Exception)
            {

                return View(product);
            }
            finally {

                if (connection != null) { 
                
                    connection.Close();
                }
            }
            return View(product);
        }
        


        [HttpGet]

        public ActionResult Create() { 
        
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {


            // Connection string to the database
            string connectionString = "server=DESKTOP-IBP9IN1\\SQLEXPRESS;database=MVCDB;integrated security=true";

            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                string query = $"insert into Product values( '{product.Name}',{product.Price})";

                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();

                int numberOfROwsAffected = cmd.ExecuteNonQuery();

                if (numberOfROwsAffected > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Create Failed";
                    return View(product);
                }

            }
            catch (Exception ex)
            {
                return View(product);
            }
            finally
            {
                if (connection != null)
                {

                    connection.Close();
                 
                }
            }
            return View(product);
        }



        [HttpGet]

        public ActionResult Delete(int id) {
            Product product = null;

            string connectionString = "server=DESKTOP-IBP9IN1\\SQLEXPRESS;database=MVCDB;integrated security=true";

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = $"select * from Product where Id = {id}";

                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {

                    while (reader.Read())
                    {
                        product = new Product()
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Price = (int)reader["Price"]
                        };
                        break;
                    }
                }
            }
            catch (Exception ex)
            {

                return View(product);
                //ViewBag.ErrorMessage = "An error occurred: " + ex.Message;

            }
            finally
            {

                if (connection != null)
                {
                    connection.Close();
                }
            }
            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            // Connection string to the database
            string connectionString = "server=DESKTOP-IBP9IN1\\SQLEXPRESS;database=MVCDB;integrated security=true";

            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                // SQL query to delete the product by ID
                string query = $"DELETE FROM Product WHERE Id = {id}";

                SqlCommand cmd = new SqlCommand(query, connection);
                int numberOfRowsAffected = cmd.ExecuteNonQuery();

                if (numberOfRowsAffected > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Delete Failed";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
                return RedirectToAction("Index");
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

    }
}