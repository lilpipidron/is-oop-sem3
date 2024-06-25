using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.NullFileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Commands;

public class Disconnect : IFileSystemCommand
{
    private readonly DisconnectContext _context;

    public Disconnect(DisconnectContext context)
    {
        _context = context;
    }

    public CommandResult Execute(SystemState systemState)
    {
        return new CommandResult.SystemStateChanged(new SystemState(string.Empty, new NullFileSystem()));
    }
}