using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ValidationApplication.Models;

namespace ValidationApplication.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View(new BookModel());
        }

        [HttpPost]
        public IActionResult CreateBook(BookModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            return LocalRedirect("/Home/Success");
        }
    }
}
