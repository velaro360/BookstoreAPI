using AutoMapper;
using BookstoreAPI.Application.Model;
using BookstoreAPI.Controllers.Requests.OrderRequests;
using BookstoreAPI.Domain.Entities;
using BookstoreAPI.Infrastructure.Repository.Interfaces;

namespace BookstoreAPI.Application.Service
{
    public interface IOrderService
    {
        Task AddOrderAsync(AddOrderRequest order);
        Task<OrderDTO?> GetOrderByIdAsync(int id);
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
    }

    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task AddOrderAsync(AddOrderRequest order)
        {
            await _orderRepository.AddOrderAsync(_mapper.Map<Order>(order));
        }

        public async Task<OrderDTO?> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null)
            {
                return null;
            }
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return _mapper.Map<List<OrderDTO>>(orders);
        }
}
