using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class Messenger : IMessenger
{
    private IMessage? _message;

    public void PrintMessage()
    {
        if (_message is null)
        {
            throw new ArgumentNullException(nameof(_message));
        }

        Console.Write($"Messenger\nTitle:\n{_message.Title}\nBody:\n{_message.Body}\n");
    }

    public void ReceiveMessage(IMessage message)
    {
        _message = message;
    }
}