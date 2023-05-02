using System;
using DesignPatterns.SOLID;
using DesignPatterns.SOLID.OpenClosed;

namespace DesignPatterns;

internal class Program
{
    static void Main(string[] args)
    {
        // SingleResponsibility.Run();
        OpenClosed.Run();

        Console.ReadKey();
    }
}