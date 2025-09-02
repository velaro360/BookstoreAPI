using System.ComponentModel.DataAnnotations;

namespace BookstoreAPI.Controllers.Requests.BookRequests
{
    public class UpdateBookRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Id must be greater than 0")]
        public int Id { get; set; }

        public string Title { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        [StringLength(4, MinimumLength = 1)]
        public string YearPublished { get; set; }

        public string Author { get; set; }

        public string AuthorId { get; set; }
    }
}
