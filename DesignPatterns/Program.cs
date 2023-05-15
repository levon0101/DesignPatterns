using System;
using DesignPatterns.SOLID;
using DesignPatterns.SOLID.DependencyInversion;
using DesignPatterns.SOLID.LiskovSubstitution;
using DesignPatterns.SOLID.OpenClosed;

namespace DesignPatterns;

internal class Program
{
    static void Main(string[] args)
    {
        // SingleResponsibility.Run();
        // OpenClosed.Run();
        // LiskovSubstitution.Run();
        DependencyInversion.Run();
        
        Console.ReadKey();
    }
}