using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ValidationApplication.Models;

namespace ValidationApplication.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book => Set<Book>();
    }
}
