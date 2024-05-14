using Microsoft.AspNetCore.Mvc;

namespace ValidationApplication.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
