using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;
using System.Windows.Controls;
using wci.App.Services;
using wci.App.Views;

namespace wci.App.ViewModels;

internal sealed partial class LoginPageViewModel(
    ILuCIService luciService,
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

    [RelayCommand]
    public void Login(PasswordBox passwordBox)
    {
        if (HasErrors)
        {
            return;
        }

        var response = luciService.Login(IpAddress, Username, passwordBox.Password);

        if (string.IsNullOrWhiteSpace(response.Error))
        {
            navigationService.Navigate(typeof(OverviewPage));
            return;
        }

        ErrorMessage = response.Error;
        
    }
}
