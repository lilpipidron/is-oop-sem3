using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseDisplays;

public class AddresseDisplay : IAddressee
{
    private readonly IDisplay _display;

    public AddresseDisplay(IDisplay display)
    {
        _display = display;
    }

    public void TransferMessage(IMessage message)
    {
        _display.ReceiveMessage(message);
    }
}