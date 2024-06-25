using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Output;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.Visitors.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Commands.TreeCommands;

public class TreeList : IFileSystemCommand
{
    private readonly int _depth;
    private readonly IOutputMode _outputMode;
    private readonly JsonVisitor _jsonVisitor;

    public TreeList(TreeListContext context)
    {
        _depth = context.Depth >= 1 ? context.Depth : 1;
        _outputMode = context.OutputMode ?? new ConsoleOutput();
        _jsonVisitor = new JsonVisitor();
    }

    public CommandResult Execute(SystemState systemState)
    {
        IEnumerable<TreeParts> tree = systemState.FileSystem.TreeList(systemState.RelativePath, _depth);
        _outputMode.Print(_jsonVisitor.Visit(tree));
        return new CommandResult.Success();
    }
}