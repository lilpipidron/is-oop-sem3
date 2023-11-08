using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseMessengers;

public class AdresseeMessenger : IAddressee
{
    private readonly IMessenger _messenger;

    public AdresseeMessenger(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void TransferMessage(IMessage message)
    {
        _messenger.ReceiveMessage(message);
    }
}