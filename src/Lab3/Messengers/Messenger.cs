using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class Messenger : IMessenger
{
    public void ReceiveMessage(IMessage message)
    {
        Console.Write($"Messenger\nTitle:\n{message.Title}\nBody:\n{message.Body}\n");
    }
}