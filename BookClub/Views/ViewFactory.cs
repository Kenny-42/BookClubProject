using BookClub.Controllers;

namespace BookClub.Views;

public class ViewFactory
{
    private readonly Dictionary<string, Func<IAppView>> _factories = new();

    public void Register<TView>(Func<TView> factory) where TView : IAppView
    {
        _factories[typeof(TView).FullName!] = () => factory();
    }

    public TView Create<TView>() where TView : IAppView
    {
        if (_factories.TryGetValue(typeof(TView).FullName!, out var factory))
        {
            return (TView)factory();
        }
        throw new InvalidOperationException($"No factory registered for type {typeof(TView).FullName}");
    }
}
