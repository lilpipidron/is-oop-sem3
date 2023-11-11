using System;
using Itmo.ObjectOrientedProgramming.Lab3.Displays.TextModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.DisplayDrivers;

public class DisplayDriverConsole : IDisplayDriver
{
    private ITextModifier? _modifier;

    public void ClearOutput()
    {
        Console.Clear();
    }

    public void SetModifier(ITextModifier textModifier)
    {
        _modifier = textModifier;
    }

    public void PrintMessage(string message)
    {
        if (_modifier is not null)
        {
            message = _modifier.Modify(message);
        }

        Console.Write(message);
    }
}