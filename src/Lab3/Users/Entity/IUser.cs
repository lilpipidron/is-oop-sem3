using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users.Entity;

public interface IUser
{
    void ReceiveMessage(Message message);

    ReadResult ReadMessage(Message message);

    MessageStatus? FindMessage(Message message);
}