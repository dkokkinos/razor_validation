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
        private readonly int _startingUpperCaseCharacters;

        public UpperCaseAttribute(int startingUpperCaseCharacters)
        {
            ErrorMessage = $"The {startingUpperCaseCharacters} first characters must be upper case.";
            _startingUpperCaseCharacters = startingUpperCaseCharacters;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-uppercase", ErrorMessage);
            context.Attributes.Add("data-val-uppercase-startingUpperCaseCharacters", $"{_startingUpperCaseCharacters}");
        }

        public override bool IsValid(object value)
        {
            if(value is string str)
            {
                if (str.Length < _startingUpperCaseCharacters)
                    return false;
                return str.Substring(0, _startingUpperCaseCharacters) == str.Substring(0, _startingUpperCaseCharacters).ToUpper();
            }
            throw new ArgumentException("value is not a string.");
        }
    }
}
