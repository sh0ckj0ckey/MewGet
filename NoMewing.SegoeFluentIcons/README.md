# NoMewing.SegoeFluentIcons

`NoMewing.SegoeFluentIcons` is a small .NET library that provides strongly typed access to the names and glyph characters of **Segoe Fluent Icons**. This library uses a source generator internally to generate the `Icons` API at build time, so you can access icons through simple members such as `Icons.Wifi`, `Icons.Picture`, or `Icons.GetAllIcons()`.

This library is a metadata library, **not** a control library. It does not render icons by itself and it does not provide XAML controls or UI components. Its purpose is simply to give you a convenient way to get the name and Unicode glyph for each icon in C# code.

## Installation

Install the package from NuGet:

```bash
dotnet add package NoMewing.SegoeFluentIcons
```

## Usage

Each icon is represented by an `IconInfo` value that contains its name and glyph character.

```csharp
var icon = NoMewing.SegoeFluentIcons.Icons.Wifi;

Console.WriteLine(icon.Name);   // Wifi
Console.WriteLine(icon.Glyph);  // '\uE701'
```

You can also get all available icons:

```csharp
var allIcons = NoMewing.SegoeFluentIcons.Icons.GetAllIcons();

foreach (var icon in allIcons)
{
    Console.WriteLine($"{icon.Name}: {icon.Glyph}");
}
```

## Font requirement

To display these glyphs correctly, the target environment must have the **Segoe Fluent Icons** font available. The text element that displays the glyph must also use that font. For example, in UWP or WinUI 3, a `TextBlock` should use the `Segoe Fluent Icons` font family. If the font is missing, or if another font is used, the glyph may not render as the expected icon.

```csharp
textBlock.FontFamily = new FontFamily("Segoe Fluent Icons");
textBlock.Text = NoMewing.SegoeFluentIcons.Icons.Wifi.Glyph.ToString();
```

## Data source

The icon metadata in this library is based on data from Microsoft's **WinUI Gallery** repository:

https://github.com/microsoft/WinUI-Gallery/blob/main/WinUIGallery/Samples/Iconography/IconsData.json

If the upstream data changes, this package may be updated in a future release.

## Disclaimer

This project is not affiliated with, endorsed by, or sponsored by Microsoft.

Segoe Fluent Icons and related assets belong to Microsoft.
