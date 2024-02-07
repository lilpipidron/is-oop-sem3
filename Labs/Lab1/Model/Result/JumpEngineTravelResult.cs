using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

public abstract record JumpEngineTravelResult
{
    private JumpEngineTravelResult()
    {
    }

    public sealed record TravelSuccess(double Time, SpecialFuel Fuel) : JumpEngineTravelResult;

    public sealed record TravelFailed : JumpEngineTravelResult;
}