using System.Drawing;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.DisplayDrivers;

public interface IDisplayDriver
{
    void ClearOutput();
    string ModifyString(string str, Color? color);
    void PrintMessage(Color? color, StreamWriter? stream, IMessage message);
}