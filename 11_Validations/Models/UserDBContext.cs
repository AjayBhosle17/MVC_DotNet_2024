using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _11_Validations.Models
{
    public class UserDBContext:DbContext
    {
        public UserDBContext(): base("name=ValidationDB") {
        

        }
        public DbSet<User> Users { get; set; }
    }
}