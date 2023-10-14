using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class EngineC : IEngine, IEngineWithSpeedDown
{
    private const double Speed = 20;
    private const int StartCost = 50;

    public double Time { get; private set; }

    public EngineTravelResult Travel(int distance)
    {
        Time = distance / Speed;
        var fuel = new SimpleFuel(distance + StartCost);
        return new EngineTravelResult.TravelSuccess(Time, fuel);
    }

    public bool SpeedDown(int distance)
    {
        double speed = Speed;
        for (int i = 0; i < distance; i++)
        {
            speed *= 0.9;
        }

        return speed > 0.1;
    }
}