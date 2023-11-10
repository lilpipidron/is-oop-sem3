using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseDisplays;

public class AddresseDisplay : IAddressee
{
    private readonly IDisplay _display;
    private readonly Color _color;

    public AddresseDisplay(IDisplay display, Color color)
    {
        _display = display;
        _color = color;
    }

    public void TransferMessage(Message message)
    {
        _display.PrintMessage(_color, $"Title:{message.Title}\nBody:{message.Body}\n");
    }
}