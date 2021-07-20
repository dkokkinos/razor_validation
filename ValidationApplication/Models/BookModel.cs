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
        [Required]
        public string SKU { get; set; }

        [Required]
        [ISBN]
        public string ISBN { get; set; }

        [Required]
        [StringLength(maximumLength: 10, MinimumLength = 4)]
        [UpperCase(2)]
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
