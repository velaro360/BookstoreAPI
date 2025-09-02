using BookstoreAPI.Domain.Entities;

namespace BookstoreAPI.Application.Model
{
    public class OrderDTO
    {
        public Customer Customer { get; set; }
        public List<Book> Books { get; set; }
    }
}
