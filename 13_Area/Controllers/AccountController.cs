using _13_Area.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _13_Area.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        UserDbContext _userDbContext=new UserDbContext();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(LoginModel login)
        {
            return View();

        }
    }
}