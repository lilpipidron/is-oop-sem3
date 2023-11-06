using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Display.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public class Display : IDisplay
{
    private readonly DisplayDriver _displayDriver = new();
    private IMessage? _message;

    public void ReceiveMessage(IMessage message)
    {
        _message = message;
    }

    public void PrintMessage(Color? color = null)
    {
        if (_message is null)
        {
            throw new ArgumentNullException(null, nameof(_message));
        }

        _displayDriver.PrintMessage(color, _message);
    }
}