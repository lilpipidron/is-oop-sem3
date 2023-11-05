using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic : ITopic
{
    private readonly string _name;
    private readonly Addressee _addressee;
    private readonly Message _message;

    public Topic(string name, Addressee addressee, Message message)
    {
        _name = name;
        _addressee = addressee;
        _message = message;
    }
}