//using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ValidatorModels
{
    public class Min18YearsIfAMember: ValidationAttribute

    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            
            if (customer.MembershipTypeId == MembershipType.UnKnown || customer.MembershipTypeId== MembershipType.PayAsYouGo) 
                                           { return ValidationResult.Success; }  /// >> On Go ::

            if (customer.BirthDate==null) { return new ValidationResult("Birth Date Is Required"); }
            
            ////// Check....
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            return (age>=18)? ValidationResult.Success
                : new ValidationResult("Customer Should be at least 18 Years old To have a Membership");

        }
       
    }
}