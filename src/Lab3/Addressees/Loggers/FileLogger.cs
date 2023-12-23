using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Loggers;

public class FileLogger : ILogger
{
    public void Log(string message)
    {
        const string filePath = "AddressLog.txt";
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
        }

        File.AppendAllText(filePath, message + "\n");
    }
}