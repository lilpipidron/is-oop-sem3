using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Commands.FileCommands;

public class FileCopy : IFileSystemCommand
{
    private readonly string _destinationPath;
    private readonly string _sourcePath;

    public FileCopy(FileCopyContext context)
    {
        _sourcePath = context.SourcePath;
        _destinationPath = context.DestinationPath;
    }

    public CommandResult Execute(SystemState systemState)
    {
        string sourcePath = systemState.FileSystem.GetRootPath(_sourcePath, systemState.RelativePath);
        string destinationPath = systemState.FileSystem.GetRootPath(_destinationPath, systemState.RelativePath);

        if (systemState.FileSystem.FileExist(sourcePath) is false)
            return new CommandResult.Failed($"File {sourcePath} doesn't exist.\nCheck and try again\n");
        if (systemState.FileSystem.DirectoryExist(systemState.FileSystem.GetDirectoryName(destinationPath)) is false)
            return new CommandResult.Failed($"Directory on path: {destinationPath} doesn't exist.\nCheck and try again\n");

        return systemState.FileSystem.FileCopy(sourcePath, destinationPath);
    }
}