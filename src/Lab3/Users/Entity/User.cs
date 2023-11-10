using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users.Entity;

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

    public ReadResult ReadMessage(IMessage message)
    {
        if (Messages[message] is true)
        {
            return new ReadResult.ReadFailed();
        }

        Messages[message] = true;
        return new ReadResult.ReadSuccess();
    }
}