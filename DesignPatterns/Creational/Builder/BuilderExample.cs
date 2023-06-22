namespace DesignPatterns.Creational.Builder;

public static class BuilderExample
{
    public static void Run()
    {

        #region Builder
        

        HtmlElementBuilder htmlBuilder = new HtmlElementBuilder("ul");

        htmlBuilder.AddChild("li", "Jhone");
        htmlBuilder.AddChild("li", "Bob");
        htmlBuilder.AddChild("li", "Ivo");
        
        Console.WriteLine(htmlBuilder.ToString());

        #endregion End Builder

        #region Fluent Builder

        HtmlElementFluentBuilder htmlFluentBuilder = new HtmlElementFluentBuilder("ul");

        htmlFluentBuilder
            .AddChildFluent("li", "flent")
            .AddChildFluent("li", "builder")
            .AddChildFluent("li", "example");

        Console.WriteLine(htmlFluentBuilder.ToString());

        #endregion End Fluent Builder

        #region Fluent Builder With Recursive Generics

        FluentBuilderWithRecursiveGenerics.Run();
        #endregion Fluent Builder With Recursive Generics

    }
}