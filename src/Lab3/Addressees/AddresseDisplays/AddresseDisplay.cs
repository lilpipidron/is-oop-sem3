using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Displays.TextModifiers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseDisplays;

public class AddresseDisplay : IAddressee
{
    private readonly IDisplay _display;
    private readonly ITextModifier _modifier;

    public AddresseDisplay(IDisplay display, ITextModifier modifier)
    {
        _display = display;
        _modifier = modifier;
    }

    public void TransferMessage(Message message)
    {
        _display.PrintMessage(_modifier, $"Title:{message.Title}\nBody:{message.Body}\n");
    }
}