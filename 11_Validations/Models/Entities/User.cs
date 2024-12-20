﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _11_Validations.Models
{
    public partial class User
    {
        // database properties
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string FaceBookProfileUrl { get; set; }

        public string Image_path { get; set; }

    }
}