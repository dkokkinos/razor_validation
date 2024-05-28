using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ValidationApplication.Data;
using ValidationApplication.Models;
using ValidationApplication.Validations;

namespace ValidationApplication.Controllers
{
    public class BookFluentValidationController : Controller
    {
        private readonly BookDbContext _dbContext;

        public BookFluentValidationController(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(new FluentValidationBookModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(FluentValidationBookModel model,
            [FromServices] IValidator<FluentValidationBookModel> validator)
        {
            var result = await validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                var modelState = new ModelStateDictionary();
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName,
                        error.ErrorMessage);
                }
                return View("Index", modelState);
            }

            _dbContext.Add(new Book()
            {
                Name = model.Name,
                AuthorName = model.AuthorName,
                Description = model.Description,
                Email = model.Email,
                Genres = model.Genres,
                ISBN = model.ISBN,
                NumberOfPages = model.NumberOfPages,
                Url = model.Url,
            });
            await _dbContext.SaveChangesAsync();

            return LocalRedirect("/Home/Success");
        }

        public async Task<IActionResult> BookExists(
            [RegularExpression("^(?:ISBN(?:-13)?:?\\ )?(?=[0-9]{13}$|(?=(?:[0-9]+[-\\ ]){4})[-\\ 0-9]{17}$)97[89][-\\ ]?[0-9]{1,5}[-\\ ]?[0-9]+[-\\ ]?[0-9]+[-\\ ]?[0-9]$")]
                string isbn)
        {
            if (ModelState.IsValid)
            {
                var isbnAlreadyExists = await _dbContext.Books.AnyAsync(x => x.ISBN == isbn);
                if (isbnAlreadyExists)
                    return Json("The ISBN already exists");
                else
                    return Json(true);
            }
            return Json("invalid ISBN");
        }
    }
}
