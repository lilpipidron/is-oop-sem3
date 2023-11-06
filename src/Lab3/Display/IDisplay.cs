using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public interface IDisplay
{
    void ReceiveMessage(IMessage message);
    void PrintMessage(Color? color = null);
}