using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

public record TravelResults
{
    private protected TravelResults()
    {
    }

    public sealed record Success(IReadOnlyCollection<IFuel> Fuel, IReadOnlyCollection<double> Time) : TravelResults;
}