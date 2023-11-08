using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User : IUser
{
    public User()
    {
        Messages = new Dictionary<IMessage, bool>();
    }

    public Dictionary<IMessage, bool> Messages { get; }

    public void ReceiveMessage(IMessage message)
    {
        Messages.Add(message, false);
    }

    public void ReadMessage(IMessage message)
    {
        if (Messages[message] is true)
        {
            throw new InvalidOperationException("This message has already been read");
        }

        Messages[message] = true;
    }
}