using CommunityToolkit.Mvvm.ComponentModel;
using wci.App.Models;
using wci.App.Services;

namespace wci.App.ViewModels;

internal sealed partial class OverviewPageViewModel(ILuCIService luciService) : ObservableObject
{
    [ObservableProperty]
    private Overview _overview = luciService.GetOverview();
}
