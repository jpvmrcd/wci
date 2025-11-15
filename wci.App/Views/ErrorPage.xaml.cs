using System.Windows.Controls;

namespace wci.App.Views;

internal sealed partial class ErrorPage : Page
{
    public ErrorPage()
    {
        InitializeComponent();
        DataContext = this;
    }
}
