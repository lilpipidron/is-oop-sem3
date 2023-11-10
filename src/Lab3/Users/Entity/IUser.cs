using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users.Entity;

public interface IUser
{
    void ReceiveMessage(IMessage message);

    ReadResult ReadMessage(IMessage message);
}