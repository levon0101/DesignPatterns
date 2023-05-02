using System.Diagnostics;

namespace DesignPatterns.SOLID;

public static class SingleResponsibility
{
    public static void Run()
    {
        //creating Journals
        var j = new Journal();
        j.AddEntry("I cried today.");
        j.AddEntry("I ate a bug.");
        Console.WriteLine(j);

        //for saving
        var p = new Persistence();
        var filename = @"c:\temp\journal.txt";
        p.SaveToFile(j, filename);
        //Process.Start(filename);
    }
}