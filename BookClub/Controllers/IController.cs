namespace BookClub.Controllers;

public interface IController
{
    event Action<Type, object?> NavigationRequested;
}
