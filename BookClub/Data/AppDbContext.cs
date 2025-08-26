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
            .HasData(
                new Account { FirstName = "Alice", LastName = "Smith", Username = "alice_smith" },
                new Account { FirstName = "Bob", LastName = "Jones", Username = "bob_jones" },
                new Account { FirstName = "Charlie", LastName = "Brown", Username = "charlie_brown" },
                new Account { FirstName = "Diana", LastName = "White", Username = "diana_white" },
                new Account { FirstName = "Ella", LastName = "Green", Username = "ella_green" }
            );

        modelBuilder.Entity<Book>()
            .HasData(
                new Book { Title = "The Silent Library", Author = "Ava Miles" },
                new Book { Title = "Gardens of Glass", Author = "Liam Frost" },
                new Book { Title = "Moonlight Archive", Author = "Elena Brook" },
                new Book { Title = "Echoes of Dust", Author = "Mason Quinn" },
                new Book { Title = "Notes from the Attic", Author = "Harper Lee" }
            );
    }
}
