using System.Drawing;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplay
{
    void ReceiveMessage(IMessage message);
    void PrintMessage(Color? color = null, StreamWriter? stream = default);
}