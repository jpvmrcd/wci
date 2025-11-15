using CommunityToolkit.Mvvm.ComponentModel;
using System.Reflection;
using wci.App.Models;
using wci.App.Services;

namespace wci.App.ViewModels;

internal sealed partial class MainWindowViewModel(ILuCIService luciService) : ObservableObject
{
    [ObservableProperty]
    private string _applicationTitle = "wci: OpenWrt WPF Command Interface";
    [ObservableProperty]
    private ICollection<SidenavItem> _sidenav = luciService.GetMenu();
    [ObservableProperty]
    private string _applicationVersion = Assembly
        .GetExecutingAssembly()!
        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()!
        .InformationalVersion;
}
