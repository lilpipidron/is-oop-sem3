using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Display.TextModifiers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display.DisplayDrivers;

public class DisplayDriver : IDisplayDriver
{
    public void ClearOutput()
    {
        Console.Clear();
    }

    public string ModifyString(string str, Color? color)
    {
        var modifier = new TextModifier(color);
        return modifier.Modify(str);
    }

    public void PrintMessage(Color? color, IMessage message)
    {
        ClearOutput();
        string modifiedMessage = ModifyString(message.Body, color);
        Console.Write($"Title:\n{message.Title}\nBody:\n{modifiedMessage}");
    }
}