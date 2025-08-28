using BookClub.Data;
using BookClub.Forms;
using BookClub.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookClub;

internal static class Program
{
    public static IServiceProvider AppServices { get; private set; }
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // This must be the first line
        ApplicationConfiguration.Initialize();

        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                // Register DbContext and configure it to use SQL Server
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

                // Register forms for dependency injection
                services.AddTransient<Login>();
                services.AddTransient<CreateAccount>();
                services.AddTransient<ResetPassword>();
                services.AddTransient<BookList>();
                services.AddTransient<AddBook>();
                services.AddTransient<DiscussionBoard>();
                services.AddTransient<Reviews>();

                // Register repositories
                services.AddScoped<AccountsRepository>();

            })
            .Build();

        // This will apply any pending migrations (including InitialCreate) when the app starts
        using (var scope = host.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Check if there are any pending migrations
            if (dbContext.Database.GetPendingMigrations().Any())
            {
                // Apply any pending migrations
                dbContext.Database.Migrate();
            }
        }

        AppServices = host.Services;

        var startForm = AppServices.GetRequiredService<Login>();
        Application.Run(startForm);
    }
}