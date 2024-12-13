using _13_Areas.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using _13_Areas.Models;

namespace _13_Areas.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        UserDbContext _userDBContext =new UserDbContext();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(LoginModel lgmodel)
        {
            if (ModelState.IsValid)
            {
                bool isAuthenticated = _userDBContext.LoginData.Any(u=>u.Email.Equals(lgmodel.Email)&& u.Password.Equals(lgmodel.Password));

                if (isAuthenticated) {

                    if (lgmodel.Email.Contains("bhosle"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "admin" });

                    }
                    else
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "user" });

                    }
                }
            }
           
            
                ViewBag.Message = "Login Failed";
                return View();
        

        }
    }
}