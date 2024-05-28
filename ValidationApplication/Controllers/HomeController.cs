using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ValidationApplication.Data;
using ValidationApplication.Models;

namespace ValidationApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookDbContext _dbContext;

        public HomeController(BookDbContext _bookContext, 
            ILogger<HomeController> logger)
        {
            _dbContext = _bookContext;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _dbContext.Books.ToListAsync();
            var bookModels = books.Select(x => new BookModel()
            {
                ISBN = x.ISBN,
                Name = x.Name,
                AuthorName = x.AuthorName,
                Description = x.Description,
                Email = x.Email,
                Genres = x.Genres,
                NumberOfPages = x.NumberOfPages,
                Url = x.Url
            }).ToList();
            return View(bookModels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
