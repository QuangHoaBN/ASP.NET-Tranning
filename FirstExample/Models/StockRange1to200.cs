using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstExample.Models
{
    public class StockRange1to200:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            return (movie.Stock > 0 && movie.Stock <= 200) ? ValidationResult.Success : new ValidationResult("The Stock should be range 1 to 200!");
        }
    }
}