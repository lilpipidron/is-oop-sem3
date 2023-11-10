using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Displays.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

internal class Program
{
    private static void Main()
    {
        var dis = new Display(new DisplayDriverConsole());
        var ms = new Message("123", "123123", 1);
        dis.ReceiveMessage(ms);
        dis.PrintMessage();
        dis.PrintMessage();
    }
}