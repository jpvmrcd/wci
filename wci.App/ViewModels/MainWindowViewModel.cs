using CommunityToolkit.Mvvm.ComponentModel;
using System.Reflection;
using wci.App.Clients;
using wci.App.Models;

namespace wci.App.ViewModels;

internal sealed partial class MainWindowViewModel(LuCIClient luciClient) : ObservableObject
{
    [ObservableProperty]
    private string _applicationTitle = "wci: OpenWrt WPF Command Interface";
    [ObservableProperty]
    private ICollection<SidenavItem> _sidenav = luciClient.GetMenu();
    [ObservableProperty]
    private string _applicationVersion = Assembly
        .GetExecutingAssembly()!
        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()!
        .InformationalVersion;
}
