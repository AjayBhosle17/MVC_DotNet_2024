using _11_Validations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ValidationsInMvc.Controllers
{
    public class UsersController : Controller
    {
        UserDBContext _dbContext;

        public UsersController()
        {
            _dbContext = new UserDBContext();
        }

        // GET: Users
        [HttpGet]
        public ActionResult Index()
        {
            // need to project List<User> => List<UserModel>
            var users = _dbContext.Users.ToList().
                Select(u => new UserModel()
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    DateOfBirth = u.DateOfBirth,
                    Email = u.Email,
                    Password = u.Password,
                    FaceBookProfileUrl = u.FaceBookProfileUrl
                });
            return View(users);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // UserModel => User

                    User dbUser = new User()
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Age = user.Age,
                        DateOfBirth = user.DateOfBirth,
                        Email = user.Email,
                        Password = user.Password,
                        FaceBookProfileUrl = user.FaceBookProfileUrl
                    };

                    _dbContext.Users.Add(dbUser);
                    _dbContext.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}