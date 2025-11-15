using System.Globalization;
using System.Windows;
using wci.App.Converters;

namespace wci.App.UnitTests.Converters;

public sealed class EmptyToVisibilityConverterTests
{
    [Fact]
    public void EmptyToVisibilityConverter_Should_Return_Visible_When_String_Value_Is_Not_Null()
    {
        var converter = new EmptyToVisibilityConverter();
        var result = converter.Convert("test", typeof(string), null, CultureInfo.InvariantCulture);
        Assert.Equal(Visibility.Visible, result);
    }

    [Fact]
    public void EmptyToVisibilityConverter_Should_Return_Hidden_When_String_Value_Is_Null()
    {
        var converter = new EmptyToVisibilityConverter();
        var result = converter.Convert(null, typeof(string), null, CultureInfo.InvariantCulture);
        Assert.Equal(Visibility.Hidden, result);
    }
}
