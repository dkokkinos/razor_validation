using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ValidationApplication.Validations;

namespace ValidationApplication.Models
{
    public class RazorBookModel
    {
        [Required]
        [StringLength(maximumLength: 10, MinimumLength = 4)]
        [UpperCase(2)]
        public string Name { get; set; }

        //[Required]
        //[ISBN]
        //[PageRemote(HttpMethod = "post",
        //    AdditionalFields = "__RequestVerificationToken",
        //    PageHandler = "CheckISBN")]
        public string ISBN { get; set; }

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

        [Range(0, 2000)]
        public int NumberOfPages { get; set; }

    }
}
