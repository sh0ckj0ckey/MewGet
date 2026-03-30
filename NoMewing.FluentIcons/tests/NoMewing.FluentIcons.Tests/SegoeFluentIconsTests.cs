namespace NoMewing.FluentIcons.Tests;

/// <summary>
/// Contains unit tests for <see cref="SegoeFluentIcons"/>.
/// </summary>
public class SegoeFluentIconsTests
{
    [Fact]
    public void Wifi_Should_Have_Correct_Metadata()
    {
        var icon = SegoeFluentIcons.Wifi;
        Assert.Equal("Wifi", icon.Name);
        Assert.Equal('\uE701', icon.Glyph);
    }

    [Fact]
    public void Bug_Should_Have_Correct_Metadata()
    {
        var icon = SegoeFluentIcons.Bug;
        Assert.Equal("Bug", icon.Name);
        Assert.Equal('\uEBE8', icon.Glyph);
    }

    [Fact]
    public void EthernetVPN_Should_Have_Correct_Metadata()
    {
        var icon = SegoeFluentIcons.EthernetVPN;
        Assert.Equal("EthernetVPN", icon.Name);
        Assert.Equal('\uF8CC', icon.Glyph);
    }

    [Theory]
    [InlineData("Picture", '\uE8B9')]
    [InlineData("SmartScreen", '\uF8A5')]
    public void Icons_Should_Have_Correct_Metadata(string expectedName, char expectedGlyph)
    {
        IconInfo icon = expectedName switch
        {
            "Picture" => SegoeFluentIcons.Picture,
            "SmartScreen" => SegoeFluentIcons.SmartScreen,
            _ => throw new ArgumentOutOfRangeException(nameof(expectedName))
        };

        Assert.Equal(expectedName, icon.Name);
        Assert.Equal(expectedGlyph, icon.Glyph);
    }
}
