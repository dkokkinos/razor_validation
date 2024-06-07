using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ValidationApplication.Resources;

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
            var localizer = context.ActionContext.HttpContext.RequestServices.GetService(typeof(IStringLocalizer<ValidationMessages>)) as IStringLocalizer<ValidationMessages>;
           
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-uppercase", string.Format( localizer.GetString("Name_UpperCase"), _startingUpperCaseCharacters ));
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
            return true;
        }
    }
}
