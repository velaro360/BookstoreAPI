using System.ComponentModel.DataAnnotations;

namespace BookstoreAPI.Application.Model
{
    public class BookDTO
    {
        [Required]
        public string Title { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        [StringLength(4, MinimumLength = 1)]
        public string YearPublished { get; set; }

        [Required]
        public string Author { get; set; }
    }
}
