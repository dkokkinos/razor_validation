using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ValidationApplication.Models;
using ValidationApplication.Resources;
using ValidationApplication.Validations;

namespace ValidationApplication.Pages
{
    public class CreateBookUsingRazorModel : PageModel
    {
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
            if (ModelState.IsValid)
            {
                return RedirectToPage("Success");
            }
            return Page();
        }

        public JsonResult OnPostCheckISBN(string isbn)
        {
            // Valid Values: true, false, undefined, null, any other string.
            return new JsonResult(true);
        }
    }
}
