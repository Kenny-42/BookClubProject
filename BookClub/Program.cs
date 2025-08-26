using BookClub.Controllers;
using BookClub.Data;
using BookClub.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookClub;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    public static void Main()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

                // Register DbContext and other dependencies
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(connectionString));

                services.AddTransient<ViewRed>();
                services.AddTransient<RedController>();

                services.AddTransient<ViewBlue>();
                services.AddTransient<BlueController>();

                services.AddTransient<LoginView>();
                services.AddTransient<LoginController>();

                services.AddTransient<RegisterView>();
                services.AddTransient<RegisterController>();

                services.AddSingleton<ViewNavigator>();

                services.AddSingleton<MainForm>();
            })
            .Build();

        ApplicationConfiguration.Initialize();

        Application.Run(host.Services.GetRequiredService<MainForm>());
    }
}