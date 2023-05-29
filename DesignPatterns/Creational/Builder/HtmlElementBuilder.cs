namespace DesignPatterns.Creational.Builder;


/// <summary>
/// The Builder design pattern separates the construction of a complex object from its representation
/// so that the same construction process can create different representations
/// </summary>
class HtmlElementBuilder
{
    private readonly string rootName;
    private HtmlElement _rootElement;
    public HtmlElementBuilder(string rootName)
    {
        this.rootName = rootName;
        _rootElement = new HtmlElement(rootName, string.Empty);
    }
    
    // not fluent
    public void AddChild(string childName, string childText)
    {
        var e = new HtmlElement(childName, childText);
        _rootElement.Elements.Add(e);
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