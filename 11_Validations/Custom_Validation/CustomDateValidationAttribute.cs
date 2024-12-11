using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _11_Validations.Custom_Validation
{
    public class CustomDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            /*return base.IsValid(value);*/

            DateTime inputDate = (DateTime)value;
            DateTime CurrentDate = DateTime.Today;

            if (inputDate <= CurrentDate)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Date of birth cannot be future date ");

            }
        }

    }
    
}