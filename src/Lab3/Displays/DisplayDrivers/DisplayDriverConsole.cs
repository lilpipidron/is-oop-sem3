using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Displays.TextModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.DisplayDrivers;

public class DisplayDriverConsole : IDisplayDriver
{
    public void ClearOutput()
    {
        Console.Clear();
    }

    public string ModifyString(string str, Color color)
    {
        var modifier = new TextColorModifier(color);
        return modifier.Modify(str);
    }

    public void PrintMessage(Color color, string message)
    {
        ClearOutput();
        string modifiedMessage = ModifyString(message, color);

        Console.Write(modifiedMessage);
    }
}