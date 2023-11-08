using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public interface IMessenger
{
    void ReceiveMessage(IMessage message);
}