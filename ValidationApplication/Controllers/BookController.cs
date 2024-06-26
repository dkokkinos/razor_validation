﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ValidationApplication.Data;
using ValidationApplication.Models;

namespace ValidationApplication.Controllers
{
    public class BookController : Controller
    {
        private readonly BookDbContext _dbContext;

        public BookController(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(new BookModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(BookModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

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
                var isbnAlreadyExists = await _dbContext.Books.AnyAsync(x=>x.ISBN == isbn);
                if (isbnAlreadyExists)
                    return Json("The ISBN already exists");
                else
                    return Json(true);
            }
            return Json("invalid ISBN");
        }

    }
}
