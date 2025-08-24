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
            modelBuilder.Entity<Account>()
                .HasIndex(a => a.Username)
                .IsUnique();

            modelBuilder.Entity<Account>()
                .HasIndex(a => a.Email)
                .IsUnique();

            modelBuilder.Entity<Account>()
                .Property(a => a.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

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
