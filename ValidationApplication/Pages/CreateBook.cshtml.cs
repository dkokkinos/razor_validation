using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ValidationApplication.Pages
{
    public class CreateObjectModel : PageModel
    {
        [BindProperty]
        public BookCreationInput Input { get; set; }

        public class BookCreationInput
        {
            [Required]
            public string SKU { get; set; }

            [Required]
            public string ISBN { get; set; }

            [Required]
            [StringLength(maximumLength: 10, MinimumLength = 4)]
            public string Name { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Url]
            public string Url { get; set; }

            public int NumberOfReaders { get; set; }
        }

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
