using BookClub.Data;
using BookClub.Models;
using Microsoft.EntityFrameworkCore;

namespace BookClub.Services;

public class AccountsService
{
    private readonly AppDbContext _context;

    public AccountsService(AppDbContext context)
    {
        _context = context;
    }

    public async void Create(Account newAccount)
    {
        _context.Accounts.Add(newAccount);
        await _context.SaveChangesAsync();
    }

    public async Task<Account?> GetByUsername(string username) =>
        await _context.Accounts.FirstOrDefaultAsync(a => a.Username == username);

    public async Task<Account?> GetByEmail(string email) =>
        await _context.Accounts.FirstOrDefaultAsync(a => a.Email == email);

}
