using BookstoreAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookstoreAPI.Infrastructure.Context
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options)
        {
        }

        DbSet<Client> Clients { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
