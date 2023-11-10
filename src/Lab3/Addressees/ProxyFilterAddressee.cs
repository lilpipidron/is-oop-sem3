using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class ProxyFilterAddressee : IAddressee
{
    private readonly int _requiredLevel;
    private readonly IAddressee _addressee;

    public ProxyFilterAddressee(IAddressee addressee, int requiredLevel)
    {
        _addressee = addressee;
        _requiredLevel = requiredLevel;
    }

    public void TransferMessage(Message message)
    {
        if (message.ImportanceLevel >= _requiredLevel)
        {
            _addressee.TransferMessage(message);
        }
    }
}