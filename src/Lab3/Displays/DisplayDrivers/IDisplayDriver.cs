using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.DisplayDrivers;

public interface IDisplayDriver
{
    void ClearOutput();
    string ModifyString(string str, Color color);
    void PrintMessage(Color color, string message);
}