using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public static class Program
{
    public static void Main()
    {
        var newEn = new EngineC(21, 21);
        Console.Write(newEn.Move(2));
    }
}