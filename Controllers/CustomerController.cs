using BookstoreAPI.Application.Service;
using BookstoreAPI.Controllers.Requests.CustomerRequests;
using BookstoreAPI.Domain.Entities;
using BookstoreAPI.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController: ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPut("add")]
        public async Task<IActionResult> AddCustomerAsync([FromBody] AddCustomerRequest customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _customerService.AddCustomerAsync(customer);

            return Ok();
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetCustomerOrdersAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
