using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ValidationApplication.Validations;

namespace ValidationApplication.Models
{
    public class RazorBookModel
    {
        [Required]
        [StringLength(maximumLength: 10, MinimumLength = 2)]
        [UpperCase(1)]
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

        [Url]
        public string Url { get; set; }

        [MinLength(1)]
        [MaxLength(10)]
        public List<string> Genres { get; set; } = new List<string>();

        [Range(10, 2000)]
        public int NumberOfPages { get; set; }

    }
}
