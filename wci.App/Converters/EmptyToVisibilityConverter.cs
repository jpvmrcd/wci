using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace wci.App.Converters;

internal sealed class EmptyToVisibilityConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string str)
        {
            return string.IsNullOrWhiteSpace(str) ? Visibility.Hidden : Visibility.Visible;
        }

        return value is null ? Visibility.Hidden : Visibility.Visible;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
