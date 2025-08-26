using BookClub.Data;
using BookClub.Views;

namespace BookClub.Controllers;

public class LoginController : IController, IDisposable
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
            Initialize();
        }
    }

    public LoginController(LoginView view, AppDbContext context)
    {
        _view = view;
        _context = context;
        Initialize();
    }

    public void Initialize()
    {
        _view.RegisterClicked += OnRegisterClicked;
        _view.ForgotPasswordClicked += OnForgotPasswordClicked;
    }

    public void Dispose()
    {
        _view.RegisterClicked -= OnRegisterClicked;
        _view.ForgotPasswordClicked -= OnForgotPasswordClicked;
    }

    private void OnRegisterClicked(object? sender, EventArgs e)
    {
        //await _accountsService.TestDatabaseOperation();
        NavigationRequested?.Invoke(RegisterView.ViewKey, null);
    }

    private void OnForgotPasswordClicked(object? sender, EventArgs e) { }
    private void OnLoginClicked(object? sender, EventArgs e) { }
}
