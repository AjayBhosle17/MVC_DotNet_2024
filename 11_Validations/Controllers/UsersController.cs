﻿using _11_Validations.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
                    FaceBookProfileUrl = u.FaceBookProfileUrl,
                    Image_path = u.Image_path
                    
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

                    /* bool isEmailExists = _dbContext.Users.Any(u => u.Email == user.Email);
                     if (isEmailExists) {

                         ModelState.AddModelError("Email", "Email Already Exists/Register");
                         return View();
                     }*/

                   
                    
                        if(user.Image!=null && user.Image.FileName!=null)
                        {
                            // upload . save file to some path on server

                            string folderPath = Server.MapPath("~/Upload");
                            string filePath = Path.Combine(folderPath, user.Image.FileName);

                            user.Image.SaveAs(filePath); // fill will save inside Upload
                            user.Image_path = $"/Upload/{user.Image.FileName}"; // it save on database


                        }
                    



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
                        FaceBookProfileUrl = user.FaceBookProfileUrl,
                        Image_path = user.Image_path
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

        [HttpGet]
        public JsonResult IsEmailExits(string Email) {

            bool isEmailExits = _dbContext.Users.Any(u => u.Email == Email);

            return Json(!isEmailExits,JsonRequestBehavior.AllowGet);
     
        }
    }
}