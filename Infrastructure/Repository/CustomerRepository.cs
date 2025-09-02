using BookstoreAPI.Domain.Entities;
using BookstoreAPI.Infrastructure.Context;
using BookstoreAPI.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookstoreAPI.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BookstoreDbContext _context;

        public CustomerRepository(BookstoreDbContext context)
        {
            _context = context;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
