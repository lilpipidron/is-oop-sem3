using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

public record ComponentResult
{
    private ComponentResult()
    {
    }

    public sealed record FullCompatible() : ComponentResult;

    public sealed record Compatible(string? Comment = null, IReadOnlyCollection<string?>? Commentaries = null) : ComponentResult;

    public sealed record Failed(string Reason) : ComponentResult;
}