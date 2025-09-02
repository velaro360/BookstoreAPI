using BookstoreAPI.Domain.Entities;

namespace BookstoreAPI.Infrastructure.Repository.Interfaces
{
    public interface IBookRepository
    {
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task<bool> DeleteBookAsync(Book book);
        Task<Book?> GetBookByIdAsync(int id);
        Task<List<Book>> GetAllBooksAsync();
        Task SaveChangesAsync();
    }
}
