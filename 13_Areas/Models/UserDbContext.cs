using _13_Areas.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _13_Areas.Models
{
    public class UserDbContext:DbContext
    {
        public DbSet<LoginModel> LoginData { get; set; }
    }
}