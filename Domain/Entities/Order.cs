namespace BookstoreAPI.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<Book> Books { get; set; }
    }
}
