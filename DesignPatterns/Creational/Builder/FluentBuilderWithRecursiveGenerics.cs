namespace DesignPatterns.Creational.Builder;

public class Person
{
    public string Name { get; set; }

    public string Position { get; set; }

    #region For easy creating builder

    public class Builder : PersonFixedJobBuilder<Builder>
    {
        
    }
    public static Builder New() => new Builder();

    #endregion

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}; {nameof(Position)}: {Position}";
    }
}

public class FluentBuilderWithRecursiveGenerics
{
    public static void Run()
    {
        #region Problem

        //PersonJobBuilder personJobBuilder = new();

        //// Called method returns PersonInfoBuilder
        //// where there is NO WorkAsA 
        //personJobBuilder
        //    .Called("Jhon")
        //    .WorkAsA("Engineer");

        #endregion

        #region Solved Problem with Recursive Generics

        var person = Person.New()
            .Called("Lev")
            .WorkAsA("Engineer")
            .Build();

        Console.WriteLine(person.ToString());
        #endregion
    }
}


#region Classical Fluent builder with inheritance problem


public class PersonInfoBuilder
{
    protected Person person = new();

    /// <summary>
    /// Problem when inheriting Called method returns PersonInfoBuilder
    /// bcoz hi didn't know other inherited classes
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public PersonInfoBuilder Called(string name)
    {
        person.Name = name;
        return this;
    }
}

public class PersonJobBuilder : PersonInfoBuilder
{

    /// <summary>
    /// Problems when calling Called then WorkAsA
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public PersonJobBuilder WorkAsA(string position)
    {
        person.Position = position;
        return this;
    }
}

#endregion

#region Fluent builder with reciursive Generics


public abstract class PersonBuilder
{
    protected Person Person { get; } = new();


    public Person Build()
    {
        return Person;
    }
}

public class PersonFixedInfoBuilder<TSelf> : PersonBuilder
where TSelf : PersonFixedInfoBuilder<TSelf>
{
    public TSelf Called(string name)
    {
        Person.Name = name;
        return (TSelf)this;
    }
}


public class PersonFixedJobBuilder<TSelf> : PersonFixedInfoBuilder<PersonFixedJobBuilder<TSelf>>
where TSelf : PersonFixedJobBuilder<TSelf>
{
    public TSelf WorkAsA(string position)
    {
        Person.Position = position;
        return (TSelf)this;
    }
}


#endregion