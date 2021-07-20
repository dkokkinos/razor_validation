using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ValidationApplication.Validations
{
    public class UpperCaseAttribute : ValidationAttribute, IClientModelValidator
    {
        public UpperCaseAttribute()
        {
            ErrorMessage = "Must be upper case.";
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-uppercase", ErrorMessage);
        }

        public override bool IsValid(object value)
        {
            if(value is string str)
            {
                return str == str.ToUpper();
            }
            throw new ArgumentException("value is not a string.");
        }
    }
}
