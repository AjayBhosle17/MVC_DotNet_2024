using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _13_Area.Models
{
    public class UserDbContext :DbContext
    {

        public DbSet<LoginModel> Logins { get; set; }
    }
}