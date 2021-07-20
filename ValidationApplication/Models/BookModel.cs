using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ValidationApplication.Models
{
    public class BookModel
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
}
