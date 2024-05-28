using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ValidationApplication.Validations;

namespace ValidationApplication.Data
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ISBN { get; set; }

        public string AuthorName { get; set; }

        public string Email { get; set; }

        public string EmailRepeated { get; set; }

        public string Description { get; set; }

        public List<string> Genres { get; set; }

        public string Url { get; set; }

        public int NumberOfPages { get; set; }

    }
}
