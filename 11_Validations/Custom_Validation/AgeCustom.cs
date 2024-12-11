using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _11_Validations.Custom_Validation
{
    public class AgeCustomAttribute:ValidationAttribute
    {
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            /* return base.IsValid(value, validationContext);*/

            if (value != null)
            {
                int age = (int)value;

                if (age >= 18 && 100>=age)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("With ur Age we are not continue to You Sorry..Best Luck For Next Time..");
                }
            }
            else
            {
                return new ValidationResult("Plz Enter Your Age");
            }
        }
    }
}