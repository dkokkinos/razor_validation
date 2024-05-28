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
    public class FluentValidationBookModel
    {
        public List<SelectListItem> GenreCollection { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Fiction", Text = "Fiction" },
            new SelectListItem { Value = "Horror", Text = "Horror" },
            new SelectListItem { Value = "Fantasy", Text = "Fantasy" },
            new SelectListItem { Value = "Mystery", Text = "Mystery" },
            new SelectListItem { Value = "Scifi", Text = "Scifi" }
         };

        [Remote(action:"BookExists", controller:"BookFluentValidation")]
        public string ISBN { get; set; }

        public string Name { get; set; }

        public string AuthorName { get; set; }

        public string Email { get; set; }

        public string EmailRepeated { get; set; }

        public string Description { get; set; }

        public List<string> Genres { get; set; } = new List<string>();

        public string Url { get; set; }

        public int NumberOfPages { get; set; }
    }
}
