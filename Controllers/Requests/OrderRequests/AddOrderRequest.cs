using BookstoreAPI.Application.Model;
using BookstoreAPI.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookstoreAPI.Controllers.Requests.OrderRequests
{
    public class AddOrderRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "CustomerId must be a positive integer.")]
        public int CustomerId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "The order must contain at least one book.")]
        public List<BookDTO> Books { get; set; }
    }
}
