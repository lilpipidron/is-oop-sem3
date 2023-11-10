using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseGroups;

public class AddresseGroup : IAddressee
{
    private readonly IReadOnlyCollection<IAddressee> _addressee;

    public AddresseGroup(IReadOnlyCollection<IAddressee> addressee)
    {
        _addressee = addressee;
    }

    public void TransferMessage(Message message)
    {
        foreach (IAddressee addressee in _addressee)
        {
            addressee.TransferMessage(message);
        }
    }
}