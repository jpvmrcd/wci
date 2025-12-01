using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;
using System.Windows.Controls;
using wci.App.Clients;
using wci.App.Services;
using wci.App.Views;

namespace wci.App.ViewModels;

internal sealed partial class LoginPageViewModel(
    LuCIClient httpClient,
    INavigationService navigationService) : ObservableValidator
{
    [ObservableProperty]
    private string? _errorMessage;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Ip address is required.")]
    private string _ipAddress = "192.168.1.1";

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Username is required.")]
    private string _username = "root";

    [ObservableProperty]
    private bool _isDemo = true;

    [RelayCommand]
    public async Task LoginAsync(PasswordBox passwordBox)
    {
        if (HasErrors)
        {
            return;
        }

        var response = await httpClient.LoginAsync(IpAddress, Username, passwordBox.Password, IsDemo);

        if (!string.IsNullOrWhiteSpace(response?.Result))
        {
            navigationService.Navigate(typeof(OverviewPage));
            return;
        }

        ErrorMessage = response?.Error ?? "Invalid credentials! Please try again.";

    }
}
