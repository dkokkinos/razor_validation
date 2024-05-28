using FluentValidation;
using System;
using ValidationApplication.Models;

namespace ValidationApplication.Validations
{
    public class CreateBookRequestValidator : AbstractValidator<FluentValidationBookModel>
    {
        public CreateBookRequestValidator()
        {
            RuleFor(x=>x.ISBN).NotEmpty();
            RuleFor(x => x.ISBN).Matches("^(?:ISBN(?:-13)?:?\\ )?(?=[0-9]{13}$|(?=(?:[0-9]+[-\\ ]){4})[-\\ 0-9]{17}$)97[89][-\\ ]?[0-9]{1,5}[-\\ ]?[0-9]+[-\\ ]?[0-9]+[-\\ ]?[0-9]$");

            RuleFor(x => x.Name).MinimumLength(2).MaximumLength(30);

            RuleFor(x => x.AuthorName).MinimumLength(3).MaximumLength(30);

            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();

            RuleFor(x=>x.Description).MaximumLength(5000);

            RuleFor(x => x.Genres).NotEmpty();

            RuleFor(x => x.Url).Must(value => value is string valueAsString &&
                (valueAsString.StartsWith("http://", StringComparison.OrdinalIgnoreCase)
                || valueAsString.StartsWith("https://", StringComparison.OrdinalIgnoreCase)
                || valueAsString.StartsWith("ftp://", StringComparison.OrdinalIgnoreCase)));
        }
    }
}
