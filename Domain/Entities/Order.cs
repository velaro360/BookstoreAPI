namespace BookstoreAPI.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public List<Book> Books { get; set; }
    }
}
