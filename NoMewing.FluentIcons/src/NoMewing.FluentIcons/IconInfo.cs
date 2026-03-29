namespace NoMewing.FluentIcons;

/// <summary>
/// Represents metadata for an icon.
/// </summary>
public readonly struct IconInfo
{
    /// <summary>
    /// Gets the name of the icon.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the Unicode character used to display the icon.
    /// </summary>
    public char Glyph { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="IconInfo"/> struct.
    /// </summary>
    /// <param name="name">The name of the icon.</param>
    /// <param name="glyph">The Unicode character used to display the icon.</param>
    public IconInfo(string name, char glyph) => (Name, Glyph) = (name, glyph);
}