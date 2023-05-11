// Liskov Substitution prnciple says that classes that substitute base class should not affect on base functionality of base(super) class
//
// In region "Breaks down Liskov Substitution principle" we can see that
// Square class overrides values of Width and Height in a wrong way
// and as a result if we are creating object like this "Rectangle newSquare = new Square();"
// not expected result, because "newSquare.Width = 5;" calls Width setter of Rectangle class
//
// Region "well example of Liskov Substitution principle" fixed version of this issue

namespace DesignPatterns.SOLID.LiskovSubstitution;

public static class LiskovSubstitution
{
    public static void Run()
    {
        Rectangle rect = new ();
        rect.Width = 3;
        rect.Height = 4;

        Square square = new();
        square.Width = 5;
        
        rect.PrintName();
        CalcArea(rect); // ok
        Console.WriteLine();
        
        square.PrintName();
        CalcArea(square); // ok
        Console.WriteLine();

        Rectangle newSquare = new Square();
        newSquare.Width = 5;
        
        //expect 35 but 0 bcoz newSquare.Width calls setter of Rectangle
        newSquare.PrintName();
        CalcArea(newSquare); 
        Console.WriteLine();
    }

    private static void CalcArea(Rectangle r)
    {
        Console.WriteLine($"Area is: {r.Width * r.Height}");
    }
}


#region Breaks down Liskov Substitution principle

// /// <summary>
// /// Rectangle that breaks down Liskov Substitution principle
// /// </summary>
// public class Rectangle
// {
//     public int Width { get; set; }
//
//     public int Height { get; set; }
//
//     public void PrintName()
//     {
//         Console.WriteLine("Rectangle");
//     }
// }
//
//
// /// <summary>
// /// Square that breaks down Liskov Substitution principle
// /// </summary>
// public class Square : Rectangle
// {
//     public int Width
//     {
//         set
//         {
//             base.Width = base.Height = value;
//         }
//     }
//     
//     public int Height
//     {
//         set
//         {
//             base.Width = base.Height = value;
//         }
//     }
//     
//     public void PrintName()
//     {
//         Console.WriteLine("Square");
//     }
// }

#endregion End Breaks down Liskov Substitution principle


#region well example of Liskov Substitution principle

/// <summary>
/// Rectangle that breaks down Liskov Substitution principle
/// </summary>
public class Rectangle
{
    public virtual int Width { get; set; }

    public virtual int Height { get; set; }

    public virtual void PrintName()
    {
        Console.WriteLine("Rectangle");
    }
}


/// <summary>
/// Square that breaks down Liskov Substitution principle
/// </summary>
public class Square : Rectangle
{
    public override int Width
    {
        set
        {
            base.Width = base.Height = value;
        }
    }
    
    public override int Height
    {
        set
        {
            base.Width = base.Height = value;
        }
    }
    
    public override void PrintName()
    {
        Console.WriteLine("Square");
    }
}

#endregion well example of Liskov Substitution principle