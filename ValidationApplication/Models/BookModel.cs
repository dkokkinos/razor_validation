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
            new SelectListItem { Value = "Fantasy", Text = "Fantasy" },
            new SelectListItem { Value = "Mystery", Text = "Mystery" },
            new SelectListItem { Value = "Scifi", Text = "Scifi" }
        };

        // Note: Uncomment or comment below validation attributes for 
        // enabling or disabling localizated messages

        //[Required]
        [Required(ErrorMessageResourceType = typeof(ValidationMessages),
            ErrorMessageResourceName = "ISBN_Required")]
        [ISBN]
        [Remote(action:"BookExists", controller:"Book")]
        public string ISBN { get; set; }

        //[Required]
        [Required(ErrorMessageResourceType = typeof(ValidationMessages),
            ErrorMessageResourceName = "Name_Required")]
        //[StringLength(maximumLength: 30, MinimumLength = 2)]
        [StringLength(maximumLength: 30, MinimumLength = 2, 
            ErrorMessageResourceType = typeof(ValidationMessages),
            ErrorMessageResourceName = "Name_Length")]
        //[UpperCase(1)]
        [UpperCase(1, ErrorMessageResourceType = typeof(ValidationMessages),
            ErrorMessageResourceName = "Name_UpperCase")]
        public string Name { get; set; }

        //[Required]
        [Required(ErrorMessageResourceType = typeof(ValidationMessages),
            ErrorMessageResourceName = "AuthorName_Required")]
        //[StringLength(maximumLength: 30, MinimumLength = 3)]
        [StringLength(maximumLength: 30, MinimumLength = 3,
            ErrorMessageResourceType = typeof(ValidationMessages),
            ErrorMessageResourceName = "AuthorName_Length")]
        public string AuthorName { get; set; }

        //[Required]
        [Required(ErrorMessageResourceType = typeof(ValidationMessages),
            ErrorMessageResourceName = "Email_Required")]
        //[EmailAddress]
        [EmailAddress(ErrorMessageResourceType = typeof(ValidationMessages),
            ErrorMessageResourceName = "Email_Validation")]
        public string Email { get; set; }

        //[Required]
        [Required(ErrorMessageResourceType = typeof(ValidationMessages),
            ErrorMessageResourceName = "EmailRepeated_Required")]
        //[EmailAddress]
        [EmailAddress(ErrorMessageResourceType = typeof(ValidationMessages),
            ErrorMessageResourceName = "EmailRepeated_Validation")]
        //[Compare("Email")]
        [Compare("Email", ErrorMessageResourceType = typeof(ValidationMessages),
           ErrorMessageResourceName = "EmailRepeated_Compare")]
        public string EmailRepeated { get; set; }

        //[StringLength(maximumLength: 5000)]
        [StringLength(maximumLength: 5000,
            ErrorMessageResourceType = typeof(ValidationMessages),
            ErrorMessageResourceName = "Description_Length")]
        public string Description { get; set; }

        //[MinLength(1)]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationMessages),
            ErrorMessageResourceName = "Genres_MinLength")]
        //[MaxLength(10)]
        [MaxLength(10, ErrorMessageResourceType = typeof(ValidationMessages),
            ErrorMessageResourceName = "MinLength_MaxLength")]
        public List<string> Genres { get; set; } = new List<string>();

        //[Url]
        [Url(ErrorMessageResourceType = typeof(ValidationMessages),
            ErrorMessageResourceName = "Url")]
        public string Url { get; set; }

        //[Range(0, 2000)]
        [Range(10, 2000,
            ErrorMessageResourceType = typeof(ValidationMessages),
            ErrorMessageResourceName = "NumberOfPages_Range")]
        public int NumberOfPages { get; set; }
    }
}
