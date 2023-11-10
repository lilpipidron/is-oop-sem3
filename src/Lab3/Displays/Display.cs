using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Displays.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IDisplay
{
    private readonly IDisplayDriver _displayDriver;
    private IMessage? _message;

    public Display(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void ReceiveMessage(IMessage message)
    {
        _message = message;
    }

    public PrintResult PrintMessage(Color? color = null)
    {
        if (_message is null)
        {
            return new PrintResult.PrintFailed();
        }

        _displayDriver.PrintMessage(color, _message);
        _message = null;
        return new PrintResult.PrintSuccess();
    }
}