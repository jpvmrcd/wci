using System.Windows.Controls;
using wci.App.ViewModels;

namespace wci.App.Views;

internal sealed partial class LoginPage : Page
{
    public LoginPageViewModel ViewModel { get; }

    public LoginPage(LoginPageViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
    }
}
