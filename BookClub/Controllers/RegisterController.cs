using BookClub.Common;
using BookClub.Data;
using BookClub.Models;
using BookClub.Views;

namespace BookClub.Controllers;

public class RegisterController : IController
{
    private readonly AppDbContext _context;
    private RegisterView _view;

    public event Action<string, object?>? NavigationRequested;
    public IView View
    {
        get => _view;
        set => _view = (RegisterView)value;
    }
    public RegisterController(RegisterView view, AppDbContext context)
    {
        _context = context;
        _view = view;
    }

    internal Result TryRegister(AccountRegistration applicant)
    {

        return Result.Fail("Implement this.");
    }
    internal void Cancel()
    {
        NavigationRequested?.Invoke(LoginView.ViewKey, null);
    }
}
