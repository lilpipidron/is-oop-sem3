using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Commands.TreeCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Local;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public abstract class Program
{
    private static SystemState _systemState = new SystemState("/home/vadim/test", new LocalFileSystem());

    public static void Main()
    {
        var context = new TreeListContext(null, 1);
        var command = new TreeList(context);
        command.Execute(_systemState);
    }
}