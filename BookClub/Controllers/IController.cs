using BookClub.Views;

namespace BookClub.Controllers;

public interface IController
{
    void Initialize();
    void Dispose();

    event Action<string, object?>? NavigationRequested;
    IView View { get; set; }
}
