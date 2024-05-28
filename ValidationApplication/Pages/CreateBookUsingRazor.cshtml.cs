using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ValidationApplication.Data;
using ValidationApplication.Models;
using ValidationApplication.Resources;
using ValidationApplication.Validations;

namespace ValidationApplication.Pages
{
    public class CreateBookUsingRazorModel : PageModel
    {
        private readonly BookDbContext _dbContext;

        public CreateBookUsingRazorModel(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<SelectListItem> GenreCollection { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Fiction", Text = "Fiction" },
            new SelectListItem { Value = "Horror", Text = "Horror" },
            new SelectListItem { Value = "Fantasy", Text = "Fantasy" },
            new SelectListItem { Value = "Mystery", Text = "Mystery" },
            new SelectListItem { Value = "Scifi", Text = "Scifi" }
         };

        [BindProperty]
        public RazorBookModel Book { get; set; }

        [BindProperty]
        [Required]
        [ISBN]
        [PageRemote(HttpMethod = "post",
            AdditionalFields = "__RequestVerificationToken",
            PageHandler = "CheckISBN")]
        public string ISBN { get; set; }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostBook()
        {
            if (!ModelState.IsValid)
                return Page();

            _dbContext.Add(new Book()
            {
                ISBN = ISBN,
                Name = Book.Name,
                AuthorName = Book.AuthorName,
                Description = Book.Description,
                Email = Book.Email,
                Genres = Book.Genres,
                NumberOfPages = Book.NumberOfPages,
                Url = Book.Url,
            });
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("Success");
        }

        public JsonResult OnPostCheckISBN(string isbn)
        {
            var isbnAlreadyExists = _dbContext.Books.Any(x => x.ISBN == isbn);
            if (isbnAlreadyExists)
                return new JsonResult("The ISBN already exists");
            else
                return new JsonResult(true);
        }
    }
}
