using System.Drawing;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Displays.TextModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.DisplayDrivers;

public class DisplayDriverFile : IDisplayDriver
{
    private readonly string _filePath;

    public DisplayDriverFile(string filePath)
    {
        _filePath = filePath;
    }

    public void ClearOutput()
    {
        File.Create(_filePath).Dispose();
    }

    public string ModifyString(string str, Color color)
    {
        var modifier = new TextColorModifier(color);
        return modifier.Modify(str);
    }

    public void PrintMessage(Color color, string message)
    {
        ClearOutput();
        string modifiedMessage = ModifyString(message, color);

        File.AppendText(_filePath).Write(modifiedMessage);
    }
}