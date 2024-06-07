using System.ComponentModel.DataAnnotations;

namespace system.Models
{
    public class Book
    {
        public Guid BookId { get; set; }

        [Required(ErrorMessage = "Please enter the name of the book")]
        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public decimal Price { get; set; }
        public DateTime BorrowingDate { get; set; }

        // Foreign Key
        public Guid AuthorId { get; set; }
        public Author? Author { get; set; }

        public ICollection<Rental>? Rentals { get; set; }
    }
}