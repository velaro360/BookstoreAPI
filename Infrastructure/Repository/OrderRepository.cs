using BookstoreAPI.Domain.Entities;
using BookstoreAPI.Infrastructure.Context;
using BookstoreAPI.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookstoreAPI.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookstoreDbContext _context;

        public OrderRepository(BookstoreDbContext context)
        {
            _context = context;
        }

        public async Task AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.Books)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
           return await _context.Orders.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
