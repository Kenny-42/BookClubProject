using BookClub.Data;
using BookClub.Views;
using Microsoft.EntityFrameworkCore;

namespace BookClub.Controllers;

public class BlueController : IController
{
    private ViewBlue _view;
    private AppDbContext _context;
    public event Action<string, object?>? NavigationRequested;
    public IView View
    {
        get => _view;
        set
        {
            _view = (ViewBlue)value;
            Initialize();
        }
    }

    public BlueController(ViewBlue view, AppDbContext context)
    {
        _view = view;
        _context = context;
        Initialize();
        var result = _context.Database.CanConnect();
        MessageBox.Show($"{result}");
    }

    private void OnToRedClicked(object? sender, EventArgs e)
    {
        NavigationRequested?.Invoke("ViewRed", null);
    }
    public void Initialize()
    {
        _view.ToRedClicked += OnToRedClicked;
    }
    public void Dispose()
    {
        _view.ToRedClicked -= OnToRedClicked;
    }
}