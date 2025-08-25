using BookClub.Controllers;

namespace BookClub.Views;

public interface IAppView
{
    void OnNavigateTo(object? parameter = null);
    void OnNavigateFrom();
    Control GetControl();
    IController Controller { get; }
}
