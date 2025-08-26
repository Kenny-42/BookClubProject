using BookClub.Views;

namespace BookClub.Controllers;

public interface IController
{
    event Action<string, object?>? NavigationRequested;
    IView View { get; set; }
}
