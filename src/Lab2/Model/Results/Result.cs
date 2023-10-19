using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;

namespace Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

public record Result
{
    private Result()
    {
    }

    public sealed record Success(IPc Pc, Collection<string> Commentaries) : Result;

    public sealed record Compatible(string Comment) : Result;

    public sealed record FullCompatible() : Result;

    public sealed record Failed(string Reason) : Result;
}