namespace DesignPatterns.Creational.Builder;

public static class FacetedBuilder
{
    public static void Run()
    {
        PersonModelBuilderFacade personModelBuilder = new PersonModelBuilderFacade();

        var person = personModelBuilder
                        .Works
                            .At("Scout")
                            .AsA("Software engineer")
                            .Earning(1000_0000)
                        .Lives
                            .In("Armenina")
                            .At("Abovyan str")
                            .WithPostcode("0001")
                        .Build();

        Console.WriteLine(person);
    }
}

public class PersonModel
{
    // address
    public string StreetAddress, Postcode, City;

    // employment
    public string CompanyName, Position;

    public int AnnualIncome;

    public override string ToString()
    {
        return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
    }
}


public class PersonModelBuilderFacade
{
    protected PersonModel Person = new();

    public PersonModelJobBuilder Works => new(Person);
    public PersonModelAddressBuilder Lives => new(Person);

    public PersonModel Build()
    {
        return Person;
    }
}


public class PersonModelJobBuilder : PersonModelBuilderFacade
{
    public PersonModelJobBuilder(PersonModel person)
    {
        this.Person = person;
    }


    public PersonModelJobBuilder At(string companyName)
    {
        Person.CompanyName = companyName;
        return this;
    }

    public PersonModelJobBuilder AsA(string position)
    {
        Person.Position = position;
        return this;
    }

    public PersonModelJobBuilder Earning(int annualIncome)
    {
        Person.AnnualIncome = annualIncome;
        return this;
    }
}

public class PersonModelAddressBuilder : PersonModelBuilderFacade
{
    public PersonModelAddressBuilder(PersonModel person)
    {
        this.Person = person;
    }


    public PersonModelAddressBuilder At(string streetAddress)
    {
        Person.StreetAddress = streetAddress;
        return this;
    }

    public PersonModelAddressBuilder WithPostcode(string postcode)
    {
        Person.Postcode = postcode;
        return this;
    }

    public PersonModelAddressBuilder In(string city)
    {
        Person.City = city;
        return this;
    }
}