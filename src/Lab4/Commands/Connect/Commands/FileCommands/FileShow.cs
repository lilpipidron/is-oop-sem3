using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Output;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Commands.FileCommands;

public class FileShow : IFileSystemCommand
{
    private readonly string _path;
    private readonly IOutputMode _outputMode;

    public FileShow(FileShowContext context)
    {
        _path = context.Path;
        _outputMode = context.OutputMode ?? new ConsoleOutput();
    }

    public CommandResult Execute(SystemState systemState)
    {
        string path = systemState.FileSystem.GetRootPath(_path, systemState.RelativePath);
        if (systemState.FileSystem.FileExist(path) is false)
            return new CommandResult.Failed($"File on path {path} doesn't exist.\n");

        CommandResult commandResult = systemState.FileSystem.FileShow(path);
        if (commandResult is not CommandResult.OutputResult outputResult)
            return commandResult;

        _outputMode.Print(outputResult.Output);
        return new CommandResult.Success();
    }
}