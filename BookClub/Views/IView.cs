using BookClub.Controllers;

namespace BookClub.Views;

public interface IView
{
    void OnNavigateTo();
    void OnNavigateFrom();
    Control GetControl();
    static string? ViewKey { get; }
    IController Controller { get; set; }
}
