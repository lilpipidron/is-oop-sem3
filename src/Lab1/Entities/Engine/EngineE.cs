using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class EngineE : IEngine, IEngineWithSpeedDown
{
    private const int StartCost = 50;
    public double Time { get; private set; }

    public EngineTravelResult Travel(int distance)
    {
        double time = double.Log(distance + 1);
        Time = time;
        var fuel = new SimpleFuel(distance + StartCost);
        return new EngineTravelResult.TravelSuccess(Time, fuel);
    }

    public bool SpeedDown(int distance)
    {
        double speed = double.Exp(distance);
        for (int i = 0; i < distance; i++)
        {
            speed *= 0.9;
        }

        return speed > 0.1;
    }
}