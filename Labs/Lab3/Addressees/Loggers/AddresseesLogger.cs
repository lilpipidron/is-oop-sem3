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

    public void TransferMessage(Message message)
    {
        _logger.Log(
            $"Message received\nTitle:\n{message.Title}\nBody:\n{message.Body}\nImportance level:\n{message.ImportanceLevel}\n");
        _addressee.TransferMessage(message);
    }
}