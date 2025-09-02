using System.ComponentModel.DataAnnotations;

namespace BookstoreAPI.Controllers.Requests.BookRequests
{
    public class CreateBookRequest
    {
        [Required]
        public string Title { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        [Required]
        [StringLength(4, MinimumLength = 1)]
        public string YearPublished { get; set; }

        [Required]
        public string Author { get; set; }
    }
}
