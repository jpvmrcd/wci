using System.Collections.ObjectModel;

namespace wci.App.Models;

public sealed record SidenavItem
{
    public string Title { get; set; } = null!;
    public string PageName { get; set; } = null!;
    public string Icon { get; set; } = null!;
    public ObservableCollection<SidenavItem> Items { get; set; } = [];
}
