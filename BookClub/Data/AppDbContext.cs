using BookClub.Models;
using Microsoft.EntityFrameworkCore;

namespace BookClub.Data;

public class AppDbContext : DbContext
{
    public DbSet<Account> accounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BookClubDb;Trusted_Connection=True;");
    }
}
