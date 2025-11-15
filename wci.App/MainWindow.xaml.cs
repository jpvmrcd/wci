using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Shell;
using wci.App.Models;
using wci.App.Services;
using wci.App.ViewModels;
using wci.App.Views;

namespace wci.App;

internal sealed partial class MainWindow : Window
{
    private readonly INavigationService _navigationService;
    public MainWindowViewModel ViewModel { get; }

    public MainWindow(MainWindowViewModel viewModel, INavigationService navigationService)
    {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();

        _navigationService = navigationService;
        _navigationService.Navigating += OnNavigating;
        _navigationService.SetFrame(RootContentFrame);
        _navigationService.Navigate(typeof(LoginPage));
        Sidenav.Visibility = Visibility.Collapsed;

        WindowChrome.SetWindowChrome(
            this,
            new WindowChrome
            {
                GlassFrameThickness = new Thickness(-1),
                ResizeBorderThickness = ResizeMode == ResizeMode.NoResize ? default : new Thickness(4),
                NonClientFrameEdges = SystemParameters.HighContrast ? NonClientFrameEdges.None :
                    NonClientFrameEdges.Right | NonClientFrameEdges.Bottom | NonClientFrameEdges.Left
            }
        );
    }

    private void Sidenav_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && sender is TreeView treeView)
        {
            SelectedItemChanged(Sidenav.ItemContainerGenerator.ContainerFromItem(treeView.SelectedItem) as TreeViewItem);
        }
    }

    private void Sidenav_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        if (e.OriginalSource is ToggleButton)
        {
            return;
        }

        if (sender is TreeView treeView)
        {
            SelectedItemChanged(Sidenav.ItemContainerGenerator.ContainerFromItem(treeView.SelectedItem) as TreeViewItem);
        }

    }

    private void Sidenav_Loaded(object sender, RoutedEventArgs e)
    {
        if (Sidenav.Items.Count <= 0)
        {
            return;
        }

        var firstItem = (TreeViewItem)Sidenav.ItemContainerGenerator.ContainerFromItem(Sidenav.Items[0]);
        firstItem?.IsSelected = true;
    }

    private void SelectedItemChanged(TreeViewItem? treeViewItem)
    {
        if (Sidenav.SelectedItem is SidenavItem navItem)
        {
            var pageType = Type.GetType($"wci.App.Views.{navItem.PageName}");
            _navigationService.Navigate(pageType ?? typeof(ErrorPage));
            if (Sidenav.ItemContainerGenerator.ContainerFromItem(navItem) is TreeViewItem tvi)
            {
                tvi?.BringIntoView();
            }
        }

        treeViewItem?.IsExpanded = !treeViewItem.IsExpanded;
    }

    private void OnNavigating(object? sender, EventArgs e)
    {
        Sidenav.Visibility = Visibility.Visible;
    }
}