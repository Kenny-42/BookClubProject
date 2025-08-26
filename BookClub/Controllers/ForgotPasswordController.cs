using BookClub.Common;
using BookClub.Data;
using BookClub.Views;

namespace BookClub.Controllers;

public class ForgotPasswordController : IController
{
    private ForgotPasswordView _view;
    private AppDbContext _context;
    public event Action<string, object?>? NavigationRequested;
    public IView View
    {
        get => _view;
        set => _view = (ForgotPasswordView)value;
    }

    public ForgotPasswordController(ForgotPasswordView view, AppDbContext context)
    {
        _view = view;
        _context = context;
    }

    internal void Cancel()
    {
        NavigationRequested?.Invoke(LoginView.ViewKey, null);
    }

    internal Result<string> OnGetPasswordClicked(string usernameEmail)
    {
        var account = _context.Accounts.FirstOrDefault(a => a.Username == usernameEmail);
        if (account == null)
        {
            account = _context.Accounts.FirstOrDefault(a => a.Email == usernameEmail);
        }

        if(account != null)
        {
            return Result<string>.Ok(account.Password);
        }
        else
        {
            return Result<string>.Fail("Account not found.");
        }
    }
}
