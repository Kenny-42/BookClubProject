using System.Windows.Forms;

namespace BookClub.Views;

public class ViewNavigator
{
    private readonly Panel _targetPanel;
    private readonly ViewFactory _viewFactory;
    private IAppView? _currentView;
    private readonly Dictionary<Type, IAppView> _viewCache = new();

    public ViewNavigator(Panel targetPanel, ViewFactory factory)
    {
        _targetPanel = targetPanel;
        _viewFactory = factory;
    }

    public void NavigateTo<TView>(object? parameter = null, bool reuse = false) where TView : IAppView
    {
        _currentView?.OnNavigateFrom();
        if (_currentView != null)
        {
            _currentView.Controller.NavigationRequested -= OnNavigationRequested;
        }

        IAppView newView;

        if (reuse && _viewCache.TryGetValue(typeof(TView), out var cachedView))
        {
            newView = cachedView;
        }
        else
        {
            newView = _viewFactory.Create<TView>();
            if (reuse)
            {
                _viewCache[typeof(TView)] = newView;
            }
        }

        newView.Controller.NavigationRequested += OnNavigationRequested;

        _targetPanel.Controls.Clear();

        var control = newView.GetControl();
        control.Dock = DockStyle.Fill;

        _targetPanel.Controls.Add(control);

        newView.OnNavigateTo(parameter);
        _currentView = newView;
    }

    private void OnNavigationRequested(Type viewType, object? parameter)
    {
        var method = typeof(ViewNavigator).GetMethod(nameof(NavigateTo))?.MakeGenericMethod(viewType);
        if (method == null)
        {
            MessageBox.Show($"Navigation failed: method NavigateTo<{viewType.Name}> not found.");
            return;
        }

        try
        {
            method.Invoke(this, new object?[] { parameter, true });
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Navigation failed: {ex.InnerException?.Message ?? ex.Message}");
        }
    }
}
