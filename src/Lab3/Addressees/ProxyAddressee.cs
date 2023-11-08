using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class ProxyAddressee : IAddressee
{
    private readonly int _requiredLevel;
    private readonly IAddressee _addressee;

    public ProxyAddressee(IAddressee addressee, int requiredLevel)
    {
        _addressee = addressee;
        _requiredLevel = requiredLevel;
    }

    public void TransferMessage(IMessage message)
    {
        if (message.ImportanceLevel >= _requiredLevel)
        {
            _addressee.TransferMessage(message);
        }
    }
}