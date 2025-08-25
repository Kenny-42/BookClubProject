using BookClub.Data;
using BookClub.Models;
using BookClub.Services;
using BookClub.Views;

namespace BookClub.Controllers;

public class LoginController : IController
{
    private readonly AccountsService _accountsService;

    public event Action<Type, object?>? NavigationRequested;
    
    public LoginController(AccountsService accountService)
    {
        _accountsService = accountService;
    }

    public async Task<Result> TryLogin(string username, string password)
    {
        if(string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            return Result.Fail("Username and password cannot be empty.");
        }

        var account = await _accountsService.GetByUsername(username);
        if (account == null)
        {
            return Result.Fail($"Account with username: {username} does not exist.");
        }

        if (account.Password != password)
        {
            return Result.Fail("Invalid username or password");
        }

        NavigationRequested?.Invoke(typeof(DashboardView), null);
        return Result.Ok();
    }

    public void Register()
    {
        NavigationRequested?.Invoke(typeof(RegisterView), null);
    }
}
