namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Models;

public abstract record CommandResult
{
    private CommandResult()
    {
    }

    public sealed record Success : CommandResult;

    public sealed record OutputResult(string Output) : CommandResult;

    public sealed record SystemStateChanged(SystemState SystemState) : CommandResult;

    public sealed record Failed(string Problem) : CommandResult;
}