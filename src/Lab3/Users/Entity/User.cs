using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users.Entity;

public class User : IUser
{
    private readonly Dictionary<Message, MessageStatus> _messages;

    public User()
    {
        _messages = new Dictionary<Message, MessageStatus>();
    }

    public void ReceiveMessage(Message message)
    {
        _messages.Add(message, new MessageStatus.StatusRead());
    }

    public ReadResult ReadMessage(Message message)
    {
        MessageStatus? status = FindMessage(message);
        if (status is null or MessageStatus.StatusRead)
        {
            return new ReadResult.ReadFailed();
        }

        _messages[message] = new MessageStatus.StatusRead();
        return new ReadResult.ReadSuccess();
    }

    public MessageStatus? FindMessage(Message message)
    {
        _messages.TryGetValue(message, out MessageStatus? status);
        return status;
    }
}