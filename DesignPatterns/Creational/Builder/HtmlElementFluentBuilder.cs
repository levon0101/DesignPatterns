namespace DesignPatterns.Creational.Builder;

/// <summary>
/// Difference between builder that AddChild returns himself
/// this is all difference between builder and fluent builder
/// </summary>
class HtmlElementFluentBuilder
{
    private readonly string rootName;
    private HtmlElement _rootElement;
    public HtmlElementFluentBuilder(string rootName)
    {
        this.rootName = rootName;
        _rootElement = new HtmlElement(rootName, string.Empty);
    }
    
    // fluent builder returns builder
    public HtmlElementFluentBuilder AddChildFluent(string childName, string childText)
    {
        var e = new HtmlElement(childName, childText);
        _rootElement.Elements.Add(e);
        return this;
    }

    public override string ToString()
    {
        return _rootElement.ToString();
    }

    public void Clear()
    {
        _rootElement = new HtmlElement(rootName, string.Empty);
    }
}