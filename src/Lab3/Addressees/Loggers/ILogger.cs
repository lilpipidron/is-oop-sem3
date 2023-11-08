using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Loggers;

public interface ILogger : IAddressee
{
    void Log(IMessage message);
}