using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _7_Bootstrap_Login_Register.Models
{
    public class RegisterViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}