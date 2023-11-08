using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Loggers;

public class AddresseesLogger : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly ILogger _logger;

    public AddresseesLogger(IAddressee addressee, ILogger logger)
    {
        _addressee = addressee;
        _logger = logger;
    }

    public void TransferMessage(IMessage message)
    {
        _logger.Log(message);
        _addressee.TransferMessage(message);
    }
}