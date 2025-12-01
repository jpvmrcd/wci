using CommunityToolkit.Mvvm.ComponentModel;
using wci.App.Clients;
using wci.App.Models;
using wci.App.Services;

namespace wci.App.ViewModels;

internal sealed partial class OverviewPageViewModel(LuCIClient luciClient) : ObservableObject
{
    [ObservableProperty]
    private Overview _overview = luciClient.GetOverview();
}
