using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _11_Validations.Models
{
    
    public  class UserModel
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="Plz Enter your First Name")]
        [MinLength(2,ErrorMessage ="First NAme Length Should be minimum 2 charcters")]
        [MaxLength(10, ErrorMessage = "Last NAme Length Should be Maximum 10 charcters")]

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Plz Enter your Last Name")]

        public string LastName { get; set; }
       
        
        [Required(ErrorMessage = "Plz Enter your Age")]
        [Range(1,100,ErrorMessage ="Plz Enter Range Between 1 to 100")]
        public int Age { get; set; }





        [DisplayName("Date Of Birth")]
        [Required(ErrorMessage ="Plz enter your DOB")]
        public DateTime DateOfBirth { get; set; }





        [Required (ErrorMessage ="Plz Enter Your Email")]

        /*Regular Expression*/
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email")]
        // [EmailAddress(ErrorMessage = "Invalid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }





        [Required]
        [Compare("Email", ErrorMessage = "email and confirm email should be same")]
        [DisplayName("Confirm Email")]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage ="Plz Enter Password")]


        [DataType(DataType.Password,ErrorMessage ="Week Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password and confirm Password should be same")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Url(ErrorMessage ="Invalid url")]
        [DataType(DataType.Url,ErrorMessage ="Invalid Url")]
        public string FaceBookProfileUrl { get; set; }
    }
}