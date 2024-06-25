using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Output;

public class ConsoleOutput : IOutputMode
{
    public void Print(string? value)
    {
        Console.WriteLine(value);
    }
}