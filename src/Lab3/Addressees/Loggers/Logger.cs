using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Loggers;

public class Logger : ILogger
{
    public void Log(IMessage message)
    {
        const string filePath = "AddressLog.txt";
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
        }

        File.AppendAllText(
            filePath,
            $"Message received\nTitle:\n{message.Title}\nBody:\n{message.Body}\nImportance level:\n{message.ImportanceLevel}\n\n");
    }
}