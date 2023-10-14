using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

public abstract record EngineTravelResult
{
    private EngineTravelResult()
    {
    }

    public sealed record TravelSuccess(double Time, SimpleFuel Fuel) : EngineTravelResult;

    public sealed record TravelFailed : EngineTravelResult;
}