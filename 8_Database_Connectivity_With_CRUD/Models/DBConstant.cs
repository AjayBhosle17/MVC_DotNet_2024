using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace _8_Database_Connectivity_With_CRUD.Models
{
    public class DBConstant
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["MVCDB2024"].ConnectionString;


            }

        }

        public static string spgetProc = "UspgetProc";
        public static string spUpdateProduct="uspUpdateProduct";
        public static string spCreateCategory = "uspCreateCategory";
        public static string spDeleteProduct = "uspDeleteProduct";
    }
}