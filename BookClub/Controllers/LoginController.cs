using BookClub.Common;
using BookClub.Data;
using BookClub.Models;
using BookClub.Views;

namespace BookClub.Controllers;

public class LoginController : IController
{
    private LoginView _view;
    private AppDbContext _context;
    public event Action<string, object?>? NavigationRequested;
    public IView View
    {
        get => _view;
        set
        {
            _view = (LoginView)value;
        }
    }

    public LoginController(LoginView view, AppDbContext context)
    {
        _view = view;
        _context = context;
    }

    internal void Register()
    {
        NavigationRequested?.Invoke(RegisterView.ViewKey, null);
    }

    internal void ForgotPassword()
    {
        NavigationRequested?.Invoke(ForgotPasswordView.ViewKey, null);
    }

    internal Result TryLogin(AccountLogin loginAttempt, object? data = null)
    {
        var account = _context.Accounts.FirstOrDefault(a => a.Username == loginAttempt.UsernameEmail);
        if (account == null)
        {
            account = _context.Accounts.FirstOrDefault(a => a.Email == loginAttempt.UsernameEmail);
        }

        if (account == null)
        {
            return Result.Fail("Account not found.");
        }

        if (account.Password != loginAttempt.Password)
        {
            return Result.Fail("Incorrect password.");
        }

        return Result.Ok("Welcome!");
    }
}
