using BookClub.Models;
using Microsoft.EntityFrameworkCore;

namespace BookClub.Data;

/// <summary>
/// Represents the database context for the application, providing access to the application's data models and enabling
/// database operations using Entity Framework Core.
/// </summary>
/// <remarks>This class is derived from <see cref="DbContext"/> and serves as the primary entry point for
/// interacting with the database. It includes <see cref="DbSet{TEntity}"/> properties for the application's entities,
/// such as <see cref="Account"/>, <see cref="Book"/>, and <see cref="Review"/>.  The <see cref="AppDbContext"/> is
/// configured using dependency injection, and its options are passed to the constructor. The <see
/// cref="OnModelCreating(ModelBuilder)"/> method is overridden to apply entity configurations from the assembly
/// containing this context.</remarks>
public class AppDbContext : DbContext
{
    /// <summary>
    /// A collection representing the accounts in the database.
    /// </summary>
    public DbSet<Account> Accounts { get; set; }

    /// <summary>
    /// A collection representing the books in the database.
    /// </summary>
    public DbSet<Book> Books { get; set; }

    /// <summary>
    /// A collection representing the reviews in the database.
    /// </summary>
    public DbSet<Review> Reviews { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    /// <summary>
    /// Configures the entity framework model for the application's database context.
    /// </summary>
    /// <remarks>This method applies all entity configurations from the assembly containing the <see
    /// cref="AppDbContext"/> class. It is called by the Entity Framework runtime during model creation and should not
    /// be called directly.</remarks>
    /// <param name="modelBuilder">The <see cref="ModelBuilder"/> used to configure the entity framework model.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply all configurations from the current assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
