using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Commands.FileCommands;

public class FileDelete : IFileSystemCommand
{
    private readonly string _path;

    public FileDelete(FileDeleteContext context)
    {
        _path = context.Path;
    }

    public CommandResult Execute(SystemState systemState)
    {
        string path = systemState.FileSystem.GetRootPath(_path, systemState.RelativePath);

        return systemState.FileSystem.FileExist(path) is false ?
            new CommandResult.Failed($"File on path {path} doesn't exist\n") :
            systemState.FileSystem.FileDelete(path);
    }
}