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

            // Check constraint to ensure Birthdate results in age between 13 and 100
            modelBuilder.Entity<Account>()
                .ToTable(tb => tb.HasCheckConstraint("CK_Birthdate_AgeRange",
                "Birthdate <= DATEADD(YEAR, -13, GETDATE()) AND Birthdate >= DATEADD(YEAR, -100, GETDATE())"));

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
