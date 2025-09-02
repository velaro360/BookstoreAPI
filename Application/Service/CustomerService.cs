using AutoMapper;
using BookstoreAPI.Application.Model;
using BookstoreAPI.Controllers.Requests.CustomerRequests;
using BookstoreAPI.Domain.Entities;
using BookstoreAPI.Infrastructure.Repository.Interfaces;

namespace BookstoreAPI.Application.Service
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(AddCustomerRequest customer);
        Task<CustomerDTO?> GetCustomerByIdAsync(int id);
    }

    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper) 
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task AddCustomerAsync(AddCustomerRequest customer)
        {
            await _customerRepository.AddCustomerAsync(_mapper.Map<Customer>(customer));
            await _customerRepository.SaveChangesAsync();
        }

        public async Task<CustomerDTO?> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return null;
            }
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task<List<CustomerDTO>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllCustomersAsync();
            return _mapper.Map<List<CustomerDTO>>(customers);
        }
}
