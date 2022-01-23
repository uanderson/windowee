namespace Windowee.Settings;

public class Window
{
    public string Name { get; set; }
    public Margin Margin { get; set; }

    public int Border { get; set; }

    public WindowPosition CalculatePosition(int monitorWidth, int monitorHeight)
    {
        var topMarginValue = CalculateMargin(Margin.Top, monitorHeight);
        var leftMarginValue = CalculateMargin(Margin.Left, monitorWidth);
        var bottomMarginValue = CalculateMargin(Margin.Bottom, monitorHeight);
        var rightMarginValue = CalculateMargin(Margin.Right, monitorWidth);

        var width = (int) (monitorWidth - leftMarginValue - rightMarginValue);
        var height = (int) (monitorHeight - topMarginValue - bottomMarginValue);

        return new WindowPosition
        {
            X = (int) leftMarginValue,
            Y = (int) topMarginValue - 20,
            Width = width,
            Height = height
        };
    }

    private double CalculateMargin(string margin, int size)
    {
        if (margin.EndsWith("%"))
        {
            var targetMargin = margin.Replace("%", "");

            return ((double) size / 100) * double.Parse(targetMargin);
        }

        return size - double.Parse(margin);
    }
}