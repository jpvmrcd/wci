using System.Windows.Controls;
using wci.App.ViewModels;

namespace wci.App.Views;

internal sealed partial class OverviewPage : Page
{
    public OverviewPageViewModel ViewModel { get; }

    public OverviewPage(OverviewPageViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
    }
}
