using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display.DisplayDrivers;

public interface IDisplayDriver
{
    void ClearOutput();
    string ModifyString(string str, Color? color);
    void PrintMessage(Color? color, IMessage message);
}