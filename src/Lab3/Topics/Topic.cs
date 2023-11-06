using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic : ITopic
{
    private readonly string _name;

    private readonly Addressee _addressee;

    private IMessage? _message;

    public Topic(string name, Addressee addressee)
    {
        _name = name;
        _addressee = addressee;
    }

    public void GetMessage(IMessage message)
    {
        _message = message;
    }
}