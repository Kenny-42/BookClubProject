using BookClub.Data;
using BookClub.Views;

namespace BookClub.Controllers;

public class RegisterController : IController, IDisposable
{
    private readonly AppDbContext _context;
    private RegisterView _view;

    public event Action<string, object?>? NavigationRequested;
    public IView View
    {
        get => _view;
        set
        {
            _view = (RegisterView)value;
            Initialize();
        }
    }
    public RegisterController(RegisterView view, AppDbContext context)
    {
        _context = context;
        _view = view;

        Initialize();
    }

    public void Initialize()
    {
        _view.CancelClicked += OnCancelClicked;
        _view.RegisterClicked += OnRegisterClicked;
    }

    public void Dispose()
    {
        _view.CancelClicked -= OnCancelClicked;
        _view.RegisterClicked -= OnRegisterClicked;
    }

    private void OnRegisterClicked(object? sender, EventArgs e) { }
    private void OnCancelClicked(object? sender, EventArgs e)
    {
        NavigationRequested?.Invoke(LoginView.ViewKey, null);
    }
}
