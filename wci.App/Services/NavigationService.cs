using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace wci.App.Services;

public interface INavigationService
{
    event EventHandler Navigating;
    void SetFrame(Frame frame);
    void Navigate(Type type);
}

internal sealed class NavigationService(IServiceProvider serviceProvider) : INavigationService
{
    private Frame? _frame;

    public event EventHandler? Navigating;

    public void SetFrame(Frame frame)
    {
        _frame = frame;
    }

    public void Navigate(Type type)
    {
        if (type == null)
        {
            return;
        }

        var page = serviceProvider.GetRequiredService(type);
        Navigating?.Invoke(this, EventArgs.Empty);
        _frame?.Navigate(page);
    }
}
