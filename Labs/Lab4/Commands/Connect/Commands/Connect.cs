using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Commands;

public class Connect : IFileSystemCommand
{
    private readonly string _address;
    private readonly IFileSystem _fileSystem;

    public Connect(ConnectContext context)
    {
        _address = context.Address;
        _fileSystem = context.FileSystem;
    }

    public CommandResult Execute(SystemState systemState)
    {
        return new CommandResult.SystemStateChanged(new SystemState(_address, _fileSystem));
    }
}