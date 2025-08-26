using BookClub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;

namespace BookClub.Data;

public class AppDbContext : DbContext
{
    public DbSet<Account> accounts { get; set; }

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
    }
}
