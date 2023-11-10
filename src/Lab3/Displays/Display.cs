using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Displays.DisplayDrivers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IDisplay
{
    private readonly IDisplayDriver _displayDriver;

    public Display(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public PrintResult PrintMessage(Color color, string message)
    {
        _displayDriver.PrintMessage(color, message);
        return new PrintResult.PrintSuccess();
    }
}