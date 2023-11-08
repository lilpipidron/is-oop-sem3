using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public interface IUser
{
    void ReceiveMessage(IMessage message);

    void ReadMessage(IMessage message);
}