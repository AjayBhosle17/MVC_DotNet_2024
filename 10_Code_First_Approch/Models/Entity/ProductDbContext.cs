using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _10_Code_First_Approch.Models.Entity
{
    public class CodeFirstDB : DbContext
    {

        //public ProductDbContext() : base("name=CodeFirstDB") { 
        

        //}
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }


    }
}