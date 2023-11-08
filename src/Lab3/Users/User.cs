using System.Collections.Generic;
using System.Data;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User : IUser
{
    private readonly Dictionary<IMessage, bool> _messages;

    public User()
    {
        _messages = new Dictionary<IMessage, bool>();
    }

    public void ReceiveMessage(IMessage message)
    {
        _messages.Add(message, false);
    }

    public void ReadMessage(IMessage message)
    {
        if (_messages[message] is true)
        {
            throw new EvaluateException("This message has already been read");
        }

        _messages[message] = true;
    }
}