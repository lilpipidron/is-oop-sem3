using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic : ITopic
{
    private readonly string _name;

    private readonly IAddressee _addressee;

    public Topic(string name, IAddressee addressee)
    {
        _name = name;
        _addressee = addressee;
    }

    public void GetMessage(IMessage message)
    {
        _addressee.TransferMessage(message);
    }
}