using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Displays.TextModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.DisplayDrivers;

public class DisplayDriverFile : IDisplayDriver
{
    private readonly string _filePath;
    private ITextModifier? _modifier;

    public DisplayDriverFile(string filePath)
    {
        _filePath = filePath;
    }

    public void ClearOutput()
    {
        File.Create(_filePath).Dispose();
    }

    public void SetModifier(ITextModifier textModifier)
    {
        _modifier = textModifier;
    }

    public void PrintMessage(string message)
    {
        ClearOutput();

        if (_modifier is not null)
        {
            message = _modifier.Modify(message);
        }

        File.AppendText(_filePath).Write(message);
    }
}