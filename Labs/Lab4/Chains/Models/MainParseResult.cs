using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;

public record MainParseResult
{
    private MainParseResult()
    {
    }

    public sealed record Success(IFileSystemCommand Command) : MainParseResult;

    public sealed record Failed(string Reason) : MainParseResult;
}