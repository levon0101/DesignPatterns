// Interface Segregation principle says, instead of create one big Interface,
// Segregate it into small parts 

namespace DesignPatterns.SOLID.InterfaceSegregation;

public static class InterfaceSegregation
{
    public static void Run()
    {
        
    }
}

public class Document
{
}

//IMachine does not follow Interface Segregation principle 
public interface IMachine
{
    void Print(Document d);
    void Fax(Document d);
    void Scan(Document d);
}

// ok if you need a multifunction machine
public class MultiFunctionPrinter : IMachine
{
    public void Print(Document d)
    {
        //
    }

    public void Fax(Document d)
    {
        //
    }

    public void Scan(Document d)
    {
        //
    }
}

/// <summary>
/// what need to do with Fax and Scan methods
/// this is example shows that IMachine does not follow Interface Segregation principle 
/// </summary>
public class OldFashionedPrinter : IMachine
{
    public void Print(Document d)
    {
        // yep
    }

    public void Fax(Document d)
    {
        throw new System.NotImplementedException();
    }

    public void Scan(Document d)
    {
        throw new System.NotImplementedException();
    }
}

#region Interface segregation

//IMachine dropping into small parts
public interface IPrinter
{
    void Print(Document d);
}

public interface IScanner
{
    void Scan(Document d);
}

public interface IFax
{
    void Fax(Document d);
}
//---------------------------------



//implementing segregated interfaces
public class Printer : IPrinter
{
    public void Print(Document d)
    {
      
    }
}

public class Photocopier : IPrinter, IScanner
{
    public void Print(Document d)
    {
        throw new System.NotImplementedException();
    }

    public void Scan(Document d)
    {
        throw new System.NotImplementedException();
    }
}

public interface IMultiFunctionDevice : IPrinter, IScanner 
{
    
}

public struct MultiFunctionMachine : IMultiFunctionDevice
{
    // compose this out of several modules
    private IPrinter printer;
    private IScanner scanner;

    public MultiFunctionMachine(IPrinter printer, IScanner scanner)
    {
        if (printer == null)
        {
            throw new ArgumentNullException(paramName: nameof(printer));
        }
        if (scanner == null)
        {
            throw new ArgumentNullException(paramName: nameof(scanner));
        }
        this.printer = printer;
        this.scanner = scanner;
    }

    public void Print(Document d)
    {
        printer.Print(d);
    }

    public void Scan(Document d)
    {
        scanner.Scan(d);
    }
}

#endregion END Interface segregation