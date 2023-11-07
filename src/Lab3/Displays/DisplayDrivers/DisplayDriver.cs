using System;
using System.Drawing;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Displays.TextModifiers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.DisplayDrivers;

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

    public void PrintMessage(Color? color, StreamWriter? stream, IMessage message)
    {
        ClearOutput();
        string modifiedMessage = ModifyString(message.Body, color);

        if (stream is null)
        {
            Console.Write($"Title:\n{message.Title}\nBody:\n{modifiedMessage}");
            return;
        }

        stream.Write($"Title:\n{message.Title}\nBody:\n{modifiedMessage}");
        stream.Dispose();
    }
}