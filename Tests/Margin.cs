using NUnit.Framework;
using Windowee.Settings;

namespace Tests;

public class MarginTests
{
    [Test]
    public void ShouldMatchTop()
    {
        var margin = Margin.Parse("20%");

        Assert.AreEqual(margin.Top, "20%");
        Assert.AreEqual(margin.Bottom, margin.Top);
        Assert.AreEqual(margin.Right, margin.Top);
        Assert.AreEqual(margin.Left, margin.Top);
    }

    [Test]
    public void ShouldOppositeMatch()
    {
        var margin = Margin.Parse("20% 10%");

        Assert.AreEqual(margin.Top, "20%");
        Assert.AreEqual(margin.Right, "10%");
        Assert.AreEqual(margin.Bottom, margin.Top);
        Assert.AreEqual(margin.Left, margin.Right);
    }

    [Test]
    public void ShouldLeftMatchRight()
    {
        var margin = Margin.Parse("20% 10% 5%");

        Assert.AreEqual(margin.Top, "20%");
        Assert.AreEqual(margin.Right, "10%");
        Assert.AreEqual(margin.Bottom, "5%");
        Assert.AreEqual(margin.Left, margin.Right);
    }

    [Test]
    public void ShouldBeSet()
    {
        var margin = Margin.Parse("20 10 5 1");

        Assert.AreEqual(margin.Top, "20");
        Assert.AreEqual(margin.Right, "10");
        Assert.AreEqual(margin.Bottom, "5");
        Assert.AreEqual(margin.Left, "1");
    }

    [Test]
    public void ShouldFallbackToDefaultIfEmptyOrNull()
    {
        var margin = Margin.Parse("");

        Assert.AreEqual(margin.Top, Margin.DefaultMargin);
        Assert.AreEqual(margin.Right, Margin.DefaultMargin);
        Assert.AreEqual(margin.Bottom, Margin.DefaultMargin);
        Assert.AreEqual(margin.Left, Margin.DefaultMargin);

        margin = Margin.Parse(null);

        Assert.AreEqual(margin.Top, Margin.DefaultMargin);
        Assert.AreEqual(margin.Right, Margin.DefaultMargin);
        Assert.AreEqual(margin.Bottom, Margin.DefaultMargin);
        Assert.AreEqual(margin.Left, Margin.DefaultMargin);
    }

    [Test]
    public void ShouldFallbackToDefaultIfInvalid()
    {
        var margin = Margin.Parse("R% K 10I");

        Assert.AreEqual(margin.Top, Margin.DefaultMargin);
        Assert.AreEqual(margin.Right, Margin.DefaultMargin);
        Assert.AreEqual(margin.Bottom, Margin.DefaultMargin);
        Assert.AreEqual(margin.Left, Margin.DefaultMargin);
    }
    
    [Test]
    public void ShouldGenerateToString()
    {
        var margin = Margin.Parse("10");

        Assert.AreEqual(margin.ToString(), "10 10 10 10");
    }
}