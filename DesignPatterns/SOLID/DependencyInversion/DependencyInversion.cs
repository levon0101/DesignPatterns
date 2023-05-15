// 1.  High-level modules should not depend on low-level modules. Both should depend on abstractions.
// 2.  Abstractions should not depend on details. Details should depend on abstractions
//

namespace DesignPatterns.SOLID.DependencyInversion;

public static class DependencyInversion
{
    public static void Run()
    {
        //Research class shows DI principle
        
        var parent = new Person {Name = "John"};
        var child1 = new Person {Name = "Chris"};
        var child2 = new Person {Name = "Matt"};

        // low-level module
        var relationships = new Relationships();
        relationships.AddParentAndChild(parent, child1);
        relationships.AddParentAndChild(parent, child2);

        // high level module 
        new Research(relationships);
        new Research(relationships as IRelationshipBrowser);
    }
}

public enum Relationship
{
    Parent,
    Child,
    Sibling
}

public class Person
{
    public string Name;
    // public DateTime DateOfBirth;
}

public interface IRelationshipBrowser
{
    IEnumerable<Person> FindAllChildrenOf(string name);
}

public class Relationships : IRelationshipBrowser // low-level
{
    private List<(Person,Relationship,Person)> relations
        = new List<(Person, Relationship, Person)>();

    public void AddParentAndChild(Person parent, Person child)
    {
        relations.Add((parent, Relationship.Parent, child));
        relations.Add((child, Relationship.Child, parent));
    }

    public List<(Person, Relationship, Person)> Relations => relations;

    public IEnumerable<Person> FindAllChildrenOf(string name)
    {
        return relations
            .Where(x => x.Item1.Name == name
                        && x.Item2 == Relationship.Parent).Select(r => r.Item3);
    }
}

public class Research
{
    /// <summary>
    /// without dependency inversion principle
    ///
    /// </summary>
    /// <param name="relationships"></param>
    public Research(Relationships relationships) 
    {
        // high-level: find all of john's children
        //var relations = relationships.Relations;
        //foreach (var r in relations
        //  .Where(x => x.Item1.Name == "John"
        //              && x.Item2 == Relationship.Parent))
        //{
        //  WriteLine($"John has a child called {r.Item3.Name}");
        //}
    }

    /// <summary>
    /// With dependency inversion principle
    /// now Research not directly depend on Relationships class
    /// </summary>
    /// <param name="browser"></param>
    public Research(IRelationshipBrowser browser) 
    {
        foreach (var p in browser.FindAllChildrenOf("John"))
        {
            Console.WriteLine($"John has a child called {p.Name}");
        }
    }
}