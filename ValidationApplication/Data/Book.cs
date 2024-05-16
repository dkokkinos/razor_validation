using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ValidationApplication.Validations;

namespace ValidationApplication.Data
{
    public class Book
    {
        public string Name { get; set; }

        public string ISBN { get; set; }

        public string AuthorName { get; set; }

        public string Email { get; set; }

        public string EmailRepeated { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public int NumberOfPages { get; set; }

    }
}
