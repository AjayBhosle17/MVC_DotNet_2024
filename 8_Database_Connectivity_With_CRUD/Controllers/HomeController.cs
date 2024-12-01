using _8_Database_Connectivity_With_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace _8_Database_Connectivity_With_CRUD.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        [HttpGet]
        public ActionResult Index(string search)
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

                /* When u write input to seach*/

                /* string query = string.Empty;*/

                /*Using Stored Procedure*/




                /* using Query*/
                /* if (string.IsNullOrEmpty(search)) {
                     query = "select * from Product";  // Query Prepare

                 }
                 else
                 {

                     query = $"select * from Product where Name like '%{search}%'";

                 }*/

                string query = "UspgetProc";
                SqlCommand cmd = new SqlCommand(query, connection);
                
                /*using stored proce*/
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Search",search);
                
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

               // string query = $"update Product set Name='{product.Name}', Price={product.Price} where Id ={product.Id}";

                /* Using Stored Procedure*/

                string query = "uspUpdateProduct";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id",product.Id);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Price", product.Price);

                SqlParameter status = new SqlParameter()
                {
                    ParameterName = "@status",
                   SqlDbType = SqlDbType.Bit,
                    Direction= ParameterDirection.Output
                };

                cmd.Parameters.Add(status);

                connection.Open();
                int numberOfRowsAffected=cmd.ExecuteNonQuery();
                


                if (numberOfRowsAffected > 0 && (bool)status.Value)
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
                /* string query = $"insert into Product values( '{product.Name}',{product.Price})";*/

                /*Used Stored Procedure*/

                string query = "uspCreateCategory";



                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Price", product.Price);

                SqlParameter id = new SqlParameter()
                {
                    ParameterName = "@Id",
                    SqlDbType=SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(id);

                SqlParameter status = new SqlParameter()
                {
                    ParameterName = "@Status",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(status);



                connection.Open();

                int numberOfROwsAffected = cmd.ExecuteNonQuery();

                if (numberOfROwsAffected > 0 && (bool)status.Value && (int)id.Value>0)
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
                // string query = $"DELETE FROM Product WHERE Id = {id}";


                // using stored procedure

                string query = "uspDeleteProduct";


                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                SqlParameter status = new SqlParameter()
                {
                    ParameterName = "@status",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(status);                
                
                
                int numberOfRowsAffected = cmd.ExecuteNonQuery();

                if (numberOfRowsAffected > 0 && (bool)status.Value)
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

        public ActionResult GetSubProduct(int id) {

            List<SubProduct> product = new List<SubProduct>();

            string connectionString = "server=DESKTOP-IBP9IN1\\SQLEXPRESS;database=MVCDB;integrated security=true";

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = $"select * from subProductId where Id = {id}";

                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader != null && reader.HasRows)
                {

                    while (reader.Read())
                    {
                        SubProduct p = new SubProduct()
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Price = (int)reader["Price"]
                        };
                        product.Add(p);
                    }
                }
                return View(product);
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index");
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

    }
}


