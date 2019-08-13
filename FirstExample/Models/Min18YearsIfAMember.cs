using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstExample.Models
{
    public class Min18YearsIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            //Nếu id=0 và 1 thì không cần kiểm tra DOB, nếu không thì ngược lại
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId==MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if (customer.DOB == null)
                return new ValidationResult("Birthday is required");
            var age = DateTime.Today.Year - customer.DOB.Value.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be at least 18 years old");
        }
    }
}