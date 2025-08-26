using BookClub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookClub;

internal static class Program
{
    public static IServiceProvider serviceProvider { get; private set; }
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
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

                services.AddTransient<Login>();
                services.AddTransient<BookList>();
            })
            .Build();

        serviceProvider = host.Services;

        var startForm = serviceProvider.GetRequiredService<Login>();

        Application.Run(startForm);
    }
}