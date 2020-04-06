using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.CustomValidation {
    public class Min18YearIfAMember : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.BirthofDate == null)
                return new ValidationResult("Birth of Date is Required.");

            var age = DateTime.Now.Year - customer.BirthofDate.Value.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer sholud be at least 18 years old to be a member.");
        }
    }
}