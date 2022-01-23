using System.Text.RegularExpressions;

namespace Windowee.Settings;

public class Margin
{
    public const string DefaultMargin = "0";

    private static readonly Regex DefaultMarginPattern = new Regex("([0-9]+)([%])?$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public readonly string Top;
    public readonly string Right;
    public readonly string Bottom;
    public readonly string Left;

    private Margin(string? top, string? right, string? bottom, string? left)
    {
        Top = ValidMarginOrDefault(top, DefaultMargin);
        Right = ValidMarginOrDefault(right, Top);
        Bottom = ValidMarginOrDefault(bottom, Top);
        Left = ValidMarginOrDefault(left, Right);
    }

    public static Margin Parse(string? value = DefaultMargin)
    {
        var margins = (value ?? string.Empty)
            .Split(" ")
            .Where(margin => !string.IsNullOrWhiteSpace(margin))
            .ToList();

        return new Margin(
            margins.ElementAtOrDefault(0),
            margins.ElementAtOrDefault(1),
            margins.ElementAtOrDefault(2),
            margins.ElementAtOrDefault(3)
        );
    }

    private string ValidMarginOrDefault(string? margin, string other)
    {
        if (string.IsNullOrWhiteSpace(margin) || !DefaultMarginPattern.IsMatch(margin))
        {
            return other;
        }

        return margin;
    }

    public bool IsDefault()
    {
        return Top == DefaultMargin && Right == DefaultMargin && Bottom == DefaultMargin && Left == DefaultMargin;
    }

    public override string ToString()
    {
        return $"{Top} {Right} {Bottom} {Left}";
    }
}