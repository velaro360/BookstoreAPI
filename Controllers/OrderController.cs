using AutoMapper;
using BookstoreAPI.Application.Model;
using BookstoreAPI.Application.Service;
using BookstoreAPI.Controllers.Requests.OrderRequests;
using BookstoreAPI.Domain.Entities;
using BookstoreAPI.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPut("add")]
        public async Task<IActionResult> AddOrderAsync([FromBody] AddOrderRequest order)
        {
            await _orderService.AddOrderAsync(order);

            return Ok();
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrderAsync([FromRoute] int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound($"No order found with id {id}");
            }

            return Ok(order);
        }

        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrdersAsync()
        {
            var orders = await _orderService.GetAllOrdersAsync();

            if (orders == null)
            {
                return NotFound("No orders found");
            }

            return Ok(orders);
        }
    }
}
