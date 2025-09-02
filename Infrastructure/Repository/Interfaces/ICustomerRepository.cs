using BookstoreAPI.Domain.Entities;

namespace BookstoreAPI.Infrastructure.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task AddCustomerAsync(Customer customer);
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task<List<Customer>> GetAllCustomersAsync();
        Task SaveChangesAsync();
    }
}
