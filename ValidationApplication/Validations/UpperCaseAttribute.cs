using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ValidationApplication.Validations
{
    public class UpperCaseAttribute : ValidationAttribute
    {
        public UpperCaseAttribute()
            : base("Must be upper case.")
        {

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
