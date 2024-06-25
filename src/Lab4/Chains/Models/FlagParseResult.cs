namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;

public record FlagParseResult
{
    private FlagParseResult()
    {
    }

    public sealed record Success<TBuilder>(RequestHandle Request, TBuilder Builder) : FlagParseResult;

    public sealed record Failed(string Reason) : FlagParseResult;
}