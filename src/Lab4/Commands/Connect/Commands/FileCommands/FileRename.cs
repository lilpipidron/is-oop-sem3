using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Commands.FileCommands;

public class FileRename : IFileSystemCommand
{
    private readonly string _name;
    private readonly string _path;

    public FileRename(FileRenameContext context)
    {
        _path = context.Path;
        _name = context.Name;
    }

    public CommandResult Execute(SystemState systemState)
    {
        string path = systemState.FileSystem.GetRootPath(_path, systemState.RelativePath);
        if (systemState.FileSystem.FileExist(path) is false)
            return new CommandResult.Failed($"File on path {path} doesn't exist.\nCheck and try again.\n");

        string? fileDirectory = systemState.FileSystem.GetDirectoryName(path);
        if (fileDirectory is null) return systemState.FileSystem.FileRename(path, _name);

        string newFileDirectory = systemState.FileSystem.PathCombine(fileDirectory, _name);
        return systemState.FileSystem.FileRename(path, newFileDirectory);
    }
}