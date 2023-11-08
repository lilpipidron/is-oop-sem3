using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Loggers;

public class AddresseesLogger : ILogger
{
    private readonly IAddressee _addressee;

    public AddresseesLogger(IAddressee addressee)
    {
        _addressee = addressee;
    }

    public void TransferMessage(IMessage message)
    {
        Log(message);
        _addressee.TransferMessage(message);
    }

    public void Log(IMessage message)
    {
        string filePath = "AddressLog.txt";
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
        }

        File.AppendAllText(
            filePath,
            $"Message received\nTitle:\n{message.Title}\nBody:\n{message.Body}\nImportance level:\n{message.ImportanceLevel}");
    }
}