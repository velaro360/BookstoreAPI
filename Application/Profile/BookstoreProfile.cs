using BookstoreAPI.Application.Model;
using BookstoreAPI.Domain.Entities;

namespace BookstoreAPI.Application.Profile
{
    public class BookstoreProfile : AutoMapper.Profile
    {
        public BookstoreProfile()
        {
            CreateMap<Book, BookDTO>();

            CreateMap<Customer, CustomerDTO>();

            CreateMap<Order, OrderDTO>();
        }
    }
}
