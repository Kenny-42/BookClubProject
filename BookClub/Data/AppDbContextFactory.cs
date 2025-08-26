using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BookClub.Data;

/// <summary>
/// Design-time factory for creating the AppDbContext instance for EF Core tools like migrations.
/// 
/// This is required because EF Core tools (e.g., `dotnet ef migrations add`) cannot access 
/// the runtime configuration. The factory ensures the DbContext is properly configured with
/// the connection string from appsettings.json.
/// </summary>
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        // Load configuration from appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        // Set up DbContext with correct connection string
        var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        // Return the configured AppDbContext
        return new AppDbContext(optionBuilder.Options);
    }
}
