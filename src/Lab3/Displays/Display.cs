using Itmo.ObjectOrientedProgramming.Lab3.Displays.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab3.Displays.TextModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IDisplay
{
    private readonly IDisplayDriver _displayDriver;

    public Display(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public PrintResult PrintMessage(ITextModifier modifier, string message)
    {
        _displayDriver.ClearOutput();
        _displayDriver.SetModifier(modifier);
        _displayDriver.PrintMessage(message);
        return new PrintResult.PrintSuccess();
    }
}