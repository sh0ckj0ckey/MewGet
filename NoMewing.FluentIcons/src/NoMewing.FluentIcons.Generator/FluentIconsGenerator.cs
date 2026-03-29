using System.Collections.Immutable;
using System.Globalization;
using System.Text;
using System.Text.Json;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace NoMewing.FluentIcons.Generator
{
    [Generator]
    internal sealed class FluentIconsGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            var iconsDataFile = context.AdditionalTextsProvider
                .Where(static file => string.Equals(System.IO.Path.GetFileName(file.Path), "IconsData.json", StringComparison.OrdinalIgnoreCase))
                .Select(static (file, cancellationToken) => file.GetText(cancellationToken)?.ToString());

            context.RegisterSourceOutput(iconsDataFile, static (sourceProductionContext, jsonText) =>
            {
                if (string.IsNullOrWhiteSpace(jsonText))
                {
                    return;
                }

                var icons = ParseIcons(jsonText);
                if (icons.Length == 0)
                {
                    return;
                }

                var source = GenerateSource(icons);
                sourceProductionContext.AddSource("SegoeFluentIcons.g.cs", SourceText.From(source, Encoding.UTF8));
            });
        }

        private static (string Name, char Glyph)[] ParseIcons(string jsonText)
        {
            using var document = JsonDocument.Parse(jsonText);

            if (document.RootElement.ValueKind != JsonValueKind.Array)
            {
                return Array.Empty<(string Name, char Glyph)>();
            }

            var icons = new List<(string Name, char Glyph)>();

            foreach (var element in document.RootElement.EnumerateArray())
            {
                if (!element.TryGetProperty("Name", out var nameProperty) ||
                    !element.TryGetProperty("Code", out var codeProperty))
                {
                    continue;
                }

                var name = nameProperty.GetString();
                var code = codeProperty.GetString();

                if (name is null || code is null)
                {
                    continue;
                }

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(code))
                {
                    continue;
                }

                if (!TryParseGlyph(code, out var glyph))
                {
                    continue;
                }

                icons.Add((name, glyph));
            }

            return icons.ToArray();
        }

        private static bool TryParseGlyph(string code, out char glyph)
        {
            glyph = default;

            if (!ushort.TryParse(code, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var value))
            {
                return false;
            }

            glyph = (char)value;
            return true;
        }
    }
}
