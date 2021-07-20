using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ValidationApplication.Resources;

namespace ValidationApplication.Models
{
    public class BookModel
    {
        [Required]
        public string SKU { get; set; }

        [Required]
        [RegularExpression("^(?:ISBN(?:-13)?:?\\ )?(?=[0-9]{13}$|(?=(?:[0-9]+[-\\ ]){4})[-\\ 0-9]{17}$)97[89][-\\ ]?[0-9]{1,5}[-\\ ]?[0-9]+[-\\ ]?[0-9]+[-\\ ]?[0-9]$",
            ErrorMessageResourceType = typeof(ValidationMessages), 
            ErrorMessageResourceName = "ISBN")]
        public string ISBN { get; set; }

        [Required]
        [StringLength(maximumLength: 10, MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        [Compare("Email")]
        public string EmailRepeated { get; set; }

        [Url]
        public string Url { get; set; }

        [Range(0, 200)]
        public int NumberOfReaders { get; set; }
    }
}
