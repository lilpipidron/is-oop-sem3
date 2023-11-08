using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Loggers;

public interface ILogger
{
    void Log(IMessage message);
}