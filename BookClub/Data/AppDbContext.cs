using BookClub.Models;
using Microsoft.EntityFrameworkCore;

namespace BookClub.Data;

public class AppDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    // TODO: Add other tables here as DbSet<T>

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configure the Account entity
        modelBuilder.Entity<Account>(entity =>
        {
            // Ensure Username is unique
            modelBuilder.Entity<Account>()
                .HasIndex(a => a.Username)
                .IsUnique();

            // Ensure Email is unique
            modelBuilder.Entity<Account>()
                .HasIndex(a => a.Email)
                .IsUnique();

            // Ensures CreatedAt has a default value of the current date and time
            modelBuilder.Entity<Account>()
                .Property(a => a.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Account>()
                .HasData(
                new Account
                {
                    AccountId = 1,
                    Username = "emmaw90",
                    Email = "emma.watkins@mail.com",
                    Birthdate = new DateTime(1990, 7, 12),
                    CreatedAt = new DateTime(2025, 1, 1), // must be fixed, not DateTime.UtcNow
                    Password = "54321" // placeholder
                },
                new Account
                {
                    AccountId = 2,
                    Username = "liamng",
                    Email = "liam.nguyen@mail.com",
                    Birthdate = new DateTime(1995, 6, 15),
                    CreatedAt = new DateTime(2025, 1, 1),
                    Password = "12345"
                },
                new Account
                {
                    AccountId = 3,
                    Username = "sophial",
                    Email = "sophia.lopez@mail.com",
                    Birthdate = new DateTime(1995, 6, 15),
                    CreatedAt = new DateTime(2025, 1, 1),
                    Password = "12345"
                },
                new Account
                {
                    AccountId = 4,
                    Username = "noahb",
                    Email = "noah.bennett@mail.com",
                    Birthdate = new DateTime(1995, 6, 15),
                    CreatedAt = new DateTime(2025, 1, 1),
                    Password = "12345"
                },
                new Account
                {
                    AccountId = 5,
                    Username = "avap",
                    Email = "ava.patel@mail.com",
                    Birthdate = new DateTime(1997, 5, 30),
                    CreatedAt = new DateTime(2025, 1, 1),
                    Password = "12345"
                }
                );

            //entity.HasKey(e => e.AccountId);
            //entity.Property(e => e.CreatedAt)
            //      .HasDefaultValueSql("GETDATE()")
            //      .ValueGeneratedOnAdd();
            //entity.Property(e => e.FirstName)
            //      .IsRequired()
            //      .HasMaxLength(64);
            //entity.Property(e => e.LastName)
            //      .IsRequired()
            //      .HasMaxLength(64);
            //entity.Property(e => e.Birthdate)
            //      .IsRequired();
            //entity.Property(e => e.Email)
            //      .IsRequired()
            //      .HasMaxLength(256);
            //entity.Property(e => e.Username)
            //      .IsRequired()
            //      .HasMaxLength(64);
            //entity.Property(e => e.PasswordHash)
            //      .IsRequired();
        });
    }
}
