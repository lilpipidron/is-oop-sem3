using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class ConsoleWriter : IWriter
{
    public void Write(string value)
    {
        Console.WriteLine(value);
    }
}