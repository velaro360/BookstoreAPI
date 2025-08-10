﻿namespace BookstoreAPI.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string YearPublished { get; set; }
        public string Author { get; set; }
        public string AuthorId { get; set; }
    }
}
