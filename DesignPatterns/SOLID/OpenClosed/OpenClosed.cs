namespace DesignPatterns.SOLID.OpenClosed;

public static class OpenClosed
{
    public static void Run()
    {
        var apple = new Product("Apple", Color.Green, Size.Small);
        var tree = new Product("Tree", Color.Green, Size.Large);
        var house = new Product("House", Color.Blue, Size.Large);

        Product[] products = { apple, tree, house };

        var pf = new ProductFilter();
        Console.WriteLine("Green products (old):");

        foreach (var p in pf.FilterByColor(products, Color.Green))
            Console.WriteLine($" - {p.Name} is green");

        Console.WriteLine();
        //------------New with OCP filter

        var bf = new BetterProductFilter();
        Console.WriteLine("Green products (new):");
        foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
            Console.WriteLine($" - {p.Name} is green");

        Console.WriteLine("Large products");
        foreach (var p in bf.Filter(products, new SizeSpecification(Size.Large)))
            Console.WriteLine($" - {p.Name} is large");

        Console.WriteLine("Large blue items");
        foreach (var p in bf.Filter(products,
                     new AndSpecification<Product>(
                             new ColorSpecification(Color.Blue),
                             new SizeSpecification(Size.Large))
                     )
                )
        {
            Console.WriteLine($" - {p.Name} is big and blue");
        }
        
        //now if we need to add one more filter, wee need just create Specification and implement ISpecification
    }
}

/// <summary>
/// This class breaks Open Closed principle
/// bcoz for every filter wee need to come there and change ProductFilter
///
/// for fix this we need to use Specification Design Pattern
/// </summary>
public class ProductFilter
{
    // let's suppose we don't want ad-hoc queries on products
    public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
    {
        foreach (var p in products)
            if (p.Color == color)
                yield return p;
    }

    public static IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
    {
        foreach (var p in products)
            if (p.Size == size)
                yield return p;
    }

    public static IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
    {
        foreach (var p in products)
            if (p.Size == size && p.Color == color)
                yield return p;
    } // state space explosion
    // 3 criteria = 7 methods

    // OCP = open for extension but closed for modification
}

#region Specification Design Pattern

public interface ISpecification<T>
{
    bool IsSatisfied(T p);
}

public interface IFilter<T>
{
    IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
}

public class ColorSpecification : ISpecification<Product>
{
    private readonly Color _color;

    public ColorSpecification(Color color)
    {
        _color = color;
    }

    public bool IsSatisfied(Product p)
    {
        return p.Color == _color;
    }
}

public class SizeSpecification : ISpecification<Product>
{
    private Size _size;

    public SizeSpecification(Size size)
    {
        _size = size;
    }

    public bool IsSatisfied(Product p)
    {
        return p.Size == _size;
    }
}
public class AndSpecification<T> : ISpecification<T>
{
    private readonly ISpecification<T> _first;
    private readonly ISpecification<T> _second;

    public AndSpecification(ISpecification<T> first, ISpecification<T> second)
    {
        _first = first;
        _second = second;
    }
    public bool IsSatisfied(T p)
    {
        return _first.IsSatisfied(p) && _second.IsSatisfied(p);
    }
}

public class BetterProductFilter : IFilter<Product>
{
    public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
    {
        foreach (var i in items)
            if (spec.IsSatisfied(i))
                yield return i;
    }
}

#endregion END Specification Design Pattern