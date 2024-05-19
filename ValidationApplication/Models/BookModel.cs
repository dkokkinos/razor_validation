using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ValidationApplication.Resources;
using ValidationApplication.Validations;

namespace ValidationApplication.Models
{
    public class BookModel
    {
        public List<SelectListItem> GenreCollection { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Fiction", Text = "Fiction" },
            new SelectListItem { Value = "Horror", Text = "Horror" },
            new SelectListItem { Value = "Fantasy", Text = "Fantasy"    },
            new SelectListItem { Value = "Mystery", Text = "Mystery" },
            new SelectListItem { Value = "Scifi", Text = "Scifi"  }
         };

        [Required]
        [ISBN]
        [Remote(action:"BookExists", controller:"Home")]
        public string ISBN { get; set; }

        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 4)]
        [UpperCase(2)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string AuthorName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        [Compare("Email")]
        public string EmailRepeated { get; set; }

        [StringLength(maximumLength: 5000)]
        public string Description { get; set; }

        [MinLength(1)]
        [MaxLength(10)]
        public List<string> Genres { get; set; } = new List<string>();

        [Url]
        public string Url { get; set; }

        [Range(0, 2000)]
        public int NumberOfPages { get; set; }
    }
}
