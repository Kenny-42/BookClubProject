using BookClub.Data;
using BookClub.Views;

namespace BookClub.Controllers;

public class RedController : IController, IDisposable
{
    private ViewRed _view;
    private AppDbContext _context;
    public event Action<string, object?>? NavigationRequested;
    public IView View
    {
        get => _view;
        set
        {
            _view = (ViewRed)value;
            Initialize();
        }
    }

    public RedController(ViewRed view, AppDbContext context)
    {
        _view = view;
        _context = context;
        Initialize();
    }

    private void OnToBlueClicked(object? sender, EventArgs e)
    {
        NavigationRequested?.Invoke("ViewBlue", null);
    }
    public void Initialize() 
    {
        _view.ToBlueClicked += OnToBlueClicked;
    }
    public void Dispose()
    {
        _view.ToBlueClicked -= OnToBlueClicked;
    }
}
