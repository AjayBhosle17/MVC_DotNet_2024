using _8_Database_Connectivity_With_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.Web.UI.WebControls;

namespace _8_Database_Connectivity_With_CRUD.Controllers
{
    public class HomeController : Controller
    {
        // storing connection string in web.config
        /*
                string _connectionString = string.Empty;
                public HomeController() {

                    _connectionString = ConfigurationManager.ConnectionStrings["MVCDB2024"].ConnectionString;
                }*/


        #region data Adapter

        public ActionResult Index(string search) {

            List<Product> product = new List<Product>();

            SqlConnection connection = new SqlConnection(DBConstant.ConnectionString);

            SqlCommand cmd = new SqlCommand(DBConstant.spgetProc, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search",search);


            SqlDataAdapter adapter = new SqlDataAdapter(cmd);


            DataSet ds = new DataSet();
            adapter.Fill(ds);

            if(ds!=null && ds.Tables!=null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                if(dt!=null && dt.Rows!=null && dt.Rows.Count > 0)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        Product pd = new Product()
                        {
                            Id = (int)row["Id"],
                            Name =(string)row["Name"],
                            Price = (int)row["Price"]
                        };
                        product.Add(pd);
                    }
                }
            }
            return View(product);
        }

        #endregion

        // GET: Home


        #region sqldataReader
        /* 
         [HttpGet]
         public ActionResult Index(string search)
         {
             List<Product> products = new List<Product>();

             // ado.net to read all Product from Product table
             //string connectionString = "server=113.193.63.106,55010;database=B24ADONETDB;user id=b24;password=b24";
             //string connectionString = "server=DESKTOP-IBP9IN1\\SQLEXPRESS;database=MVCDB;integrated security=true";


             //Sql Connection
             *//*
                         SqlConnection connection = new SqlConnection();
                         connection.ConnectionString = connectionString;*//*
             //above 2 line convert in 1 line

             SqlConnection connection = null;
             try
             {
                 connection = new SqlConnection(DBConstant.ConnectionString);
                 connection.Open(); // connection is prepare

                 *//* When u write input to seach*/

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

        /*string query = "UspgetProc";*//*
        SqlCommand cmd = new SqlCommand(DBConstant.spgetProc, connection);

        *//*using stored proce*//*
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
*/

        #endregion sqldataReader



        [HttpGet]
        public ActionResult Details(int id) {

            Product products = null;

            // ado.net to read all Product from Product table
            //string connectionString = "server=DESKTOP-IBP9IN1\\SQLEXPRESS;database=MVCDB;integrated security=true";

            //Sql Connection
            /*
                        SqlConnection connection = new SqlConnection();
                        connection.ConnectionString = connectionString;*/
            //above 2 line convert in 1 line

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(DBConstant.ConnectionString);
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

            //string connectionString = "server=DESKTOP-IBP9IN1\\SQLEXPRESS;database=MVCDB;integrated security=true";

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(DBConstant.ConnectionString);
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
            catch (Exception )
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
            //string connectionString = "server=DESKTOP-IBP9IN1\\SQLEXPRESS;database=MVCDB;integrated security=true";

            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(DBConstant.ConnectionString);

               // string query = $"update Product set Name='{product.Name}', Price={product.Price} where Id ={product.Id}";

                /* Using Stored Procedure*/

               /* string query = "uspUpdateProduct";*/

                SqlCommand cmd = new SqlCommand(DBConstant.spUpdateProduct, connection);
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
         /*   return View(product);*/
        }
        


        [HttpGet]

        public ActionResult Create() { 
        
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {


            // Connection string to the database
            //string connectionString = "server=DESKTOP-IBP9IN1\\SQLEXPRESS;database=MVCDB;integrated security=true";

            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(DBConstant.ConnectionString);
                /* string query = $"insert into Product values( '{product.Name}',{product.Price})";*/

                /*Used Stored Procedure*/

               /* string query = "uspCreateCategory";*/



                SqlCommand cmd = new SqlCommand(DBConstant.spCreateCategory, connection);
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
            catch (Exception )
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
            /*return View(product);*/
        }



        [HttpGet]

        public ActionResult Delete(int id) {
            Product product = null;

            //string connectionString = "server=DESKTOP-IBP9IN1\\SQLEXPRESS;database=MVCDB;integrated security=true";

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(DBConstant.ConnectionString);
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
            catch (Exception )
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
            //string connectionString = "server=DESKTOP-IBP9IN1\\SQLEXPRESS;database=MVCDB;integrated security=true";

            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(DBConstant.ConnectionString);
                connection.Open();

                // SQL query to delete the product by ID
                // string query = $"DELETE FROM Product WHERE Id = {id}";


                // using stored procedure

               /* string query = "uspDeleteProduct";*/


                SqlCommand cmd = new SqlCommand(DBConstant.spDeleteProduct, connection);
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
            catch (Exception )
            {
                // Handle exceptions
                ViewBag.ErrorMessage = "An error occurred: ";
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

        [HttpGet]
        public ActionResult GetSubProduct(int id) {

            List<SubProduct> product = new List<SubProduct>();

            //string connectionString = "server=DESKTOP-IBP9IN1\\SQLEXPRESS;database=MVCDB;integrated security=true";

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(DBConstant.ConnectionString);
                connection.Open();

                string query = $"select * from SubProduct where Product_Id = {id}";

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
            catch (Exception)
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
            /*return View(product);*/
        }

    }
}


