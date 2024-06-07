using Microsoft.EntityFrameworkCore;
using system.Models;

namespace system.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Rental> Rentals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the Author-Book relationship
        modelBuilder.Entity<Author>()
            .HasMany(a => a.Books)
            .WithOne(b => b.Author)
            .HasForeignKey(b => b.AuthorId);

        // Configure the Book-Rental relationship
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Rentals)
            .WithOne(r => r.Book)
            .HasForeignKey(r => r.BookId);

        // Configure the Price property of Book
        modelBuilder.Entity<Book>()
            .Property(b => b.Price)
            .HasColumnType("decimal(18,2)");
    }

}