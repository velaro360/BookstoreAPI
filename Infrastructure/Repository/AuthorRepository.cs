using BookstoreAPI.Domain.Entities;
using BookstoreAPI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BookstoreAPI.Infrastructure.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookstoreDbContext _context;

        public AuthorRepository(BookstoreDbContext context)
        {
            _context = context;
        }

        public async Task AddAuthorAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            _context.Authors.Update(author);
            await Task.CompletedTask;
        }

        public async Task DeleteAuthorAsync(Author author)
        {
            _context.Authors.Remove(author);
            await Task.CompletedTask;
        }

        public async Task<Author?> GetAuthorByIdAsync(int id)
        {
            return await _context.Authors.FindAsync(id);
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
