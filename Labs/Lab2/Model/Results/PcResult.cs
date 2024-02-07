using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;

namespace Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

public record PcResult
{
    private PcResult()
    {
    }

    public sealed record Success(IPc Pc, IReadOnlyCollection<string?>? Commentaries) : PcResult;

    public sealed record Failed(string Reason) : PcResult;
}