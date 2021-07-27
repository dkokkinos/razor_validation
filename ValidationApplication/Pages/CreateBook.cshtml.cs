using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ValidationApplication.Models;

namespace ValidationApplication.Pages
{
    public class CreateBookModel : PageModel
    {
        [BindProperty]
        public BookModel Input { get; set; }

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
    }
}
