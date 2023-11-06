using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public interface IMessenger
{
    void PrintMessage();
    void ReceiveMessage(IMessage message);
}