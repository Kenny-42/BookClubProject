using BookClub.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub.Views;

public class ViewNavigator
{
    private IView? _currentView = null;
    private readonly Panel _panel;
    private readonly Dictionary<string, IView> _views = new();
    private readonly IServiceProvider _serviceProvider;

    public ViewNavigator(Panel panel, IServiceProvider serviceProvider)
    {
        _panel = panel;
        _serviceProvider = serviceProvider;
    }

    public void RegisterView<TView, TController>(string key)
        where TView : IView
        where TController : IController
    {
        if (_views.ContainsKey(key))
        {
            throw new ArgumentException($"A view with key `{key}` already exists.");
        }

        var view = _serviceProvider.GetRequiredService<TView>();
        var controller = _serviceProvider.GetRequiredService<TController>();
        controller.View = view;

        controller.NavigationRequested += (k, d) => NavigateTo(k, d);

        _views[key] = view;

        var control = view.GetControl();
        control.Dock = DockStyle.Fill;
        control.Visible = false;
        _panel.Controls.Add(control);
    }


    public void NavigateTo(string key, object? data = null)
    {
        if (!_views.TryGetValue(key, out var newView))
            throw new ArgumentException($"No view registered with key '{key}'.");

        SwitchViews(newView);
    }

    private void SwitchViews(IView newView)
    {
        _currentView?.OnNavigateTo();

        var newControl = newView.GetControl();
        newControl.Visible = true;
        newControl.BringToFront();

        if (_currentView != null)
        {
            var oldControl = _currentView.GetControl();
            oldControl.Visible = false;
        }

        _currentView?.OnNavigateFrom();

        _currentView = newView;
    }
}
