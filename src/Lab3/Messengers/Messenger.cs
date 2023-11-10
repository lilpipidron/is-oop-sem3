using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class Messenger : IMessenger
{
    public void PrintMessage(string message)
    {
        Console.Write($"Messenger\n{message}\n");
    }
}