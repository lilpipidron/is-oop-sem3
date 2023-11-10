using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplay
{
    void ReceiveMessage(IMessage message);
    PrintResult PrintMessage(Color? color = null);
}