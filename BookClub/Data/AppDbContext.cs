using BookClub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;

namespace BookClub.Data;

public class AppDbContext : DbContext
{
    public DbSet<Account> accounts { get; set; }
    public DbSet<Book> books { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>()
            .Property(a => a.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Account>()
            .HasData(
                new Account { Id = 1, FirstName = "Alice", LastName = "Smith", Username = "alice_smith", Password = "123456" },
                new Account { Id = 2, FirstName = "Bob", LastName = "Jones", Username = "bob_jones", Password = "123456" },
                new Account { Id = 3, FirstName = "Charlie", LastName = "Brown", Username = "charlie_brown", Password = "123456" },
                new Account { Id = 4, FirstName = "Diana", LastName = "White", Username = "diana_white", Password = "123456" },
                new Account { Id = 5, FirstName = "Ella", LastName = "Green", Username = "ella_green", Password = "123456" }
            );

        modelBuilder.Entity<Book>()
            .HasData(
                new Book { Id = 1, Title = "The Silent Library", Author = "Ava Miles", Description = "A suspenseful thriller set in an eerie town.", ISBN = "9780451491234" },
                new Book { Id = 2, Title = "Gardens of Glass", Author = "Liam Frost", Description = "A poetic journey through forgotten landscapes.", ISBN = "9780143110433" },
                new Book { Id = 3, Title = "Moonlight Archive", Author = "Elena Brook", Description = "A tale of lost civilizations and secret histories.", ISBN = "9780670022450" },
                new Book { Id = 4, Title = "Echoes of Dust", Author = "Mason Quinn", Description = "A gritty sci-fi about survival on a dying planet.", ISBN = "9780316095839" },
                new Book { Id = 5, Title = "Notes from the Attic", Author = "Harper Lee", Description = "Short stories and memories from a reclusive writer.", ISBN = "9780061120084" }
            );
    }
}
