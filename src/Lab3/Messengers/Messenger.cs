namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class Messenger : IMessenger
{
    private readonly IWriter _writer;

    public Messenger(IWriter writer)
    {
        _writer = writer;
    }

    public void PrintMessage(string message)
    {
        _writer.Write($"Messenger\n{message}\n");
    }
}