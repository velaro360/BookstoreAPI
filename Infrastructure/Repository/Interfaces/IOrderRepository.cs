using BookstoreAPI.Domain.Entities;

namespace BookstoreAPI.Infrastructure.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(Order order);
        Task<Order?> GetOrderByIdAsync(int id);
        Task<List<Order>> GetAllOrdersAsync();
        Task SaveChangesAsync();
    }
}
