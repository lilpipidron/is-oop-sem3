using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public interface IUser
{
    void GetMessage(IMessage message);

    void ReadMessage(IMessage message);
}