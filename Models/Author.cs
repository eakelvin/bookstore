using System.ComponentModel.DataAnnotations;

namespace system.Models
{
    public class Author
    {
        public Guid AuthorId { get; set; }

        [Required(ErrorMessage = "Please enter a Name")]
        public string? Name { get; set; }

        public string? Biography { get; set; }
        // public ICollection<Book>? Books { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();

    }
}