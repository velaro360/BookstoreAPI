using BookstoreAPI.Domain.Entities;

public interface IAuthorRepository
{
    Task AddAuthorAsync(Author author);
    Task UpdateAuthorAsync(Author author);
    Task DeleteAuthorAsync(Author author);
    Task<Author?> GetAuthorByIdAsync(int id);
    Task<List<Author>> GetAllAuthorsAsync();
    Task SaveChangesAsync();
}