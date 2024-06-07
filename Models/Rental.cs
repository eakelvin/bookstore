namespace system.Models;
public class Rental
{
    public Guid RentalId { get; set; }
    public string? ISBN { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime DueDate { get; set; }

    public Guid BookId { get; set; }
    public Book? Book { get; set; }
}

