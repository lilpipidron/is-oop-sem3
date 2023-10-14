using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class OmegaEngine : IJumpEngine
{
    public double JumpDistance { get; init; } = 20;
    public SpecialFuel Fuel { get; init; } = new();
    public double Time { get; private set; }

    public JumpEngineTravelResult Travel(int distance)
    {
        if (distance > JumpDistance)
        {
            return new JumpEngineTravelResult.TravelFailed();
        }

        Time = distance / JumpDistance;
        Fuel.Use(Time);
        return new JumpEngineTravelResult.TravelSuccess(Time, Fuel);
    }
}