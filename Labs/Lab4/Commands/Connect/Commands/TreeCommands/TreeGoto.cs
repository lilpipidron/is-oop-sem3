using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Commands.TreeCommands;

public class TreeGoto : IFileSystemCommand
{
    private readonly string _path;

    public TreeGoto(TreeGotoContext context)
    {
        _path = context.Path;
    }

    public CommandResult Execute(SystemState systemState)
    {
        systemState.SetNewPath(_path);
        return new CommandResult.SystemStateChanged(systemState);
    }
}