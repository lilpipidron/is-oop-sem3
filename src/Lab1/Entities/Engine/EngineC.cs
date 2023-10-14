using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class EngineC : IEngine, IEngineWithSpeedDown
{
    private const double Speed = 20;
    private const int StartCost = 20;

    public double Time { get; private set; }
    public SimpleFuel Fuel { get; } = new();

    public EngineTravelResult Travel(int distance)
    {
        Time = distance / Speed;
        Fuel.Use(distance + StartCost);
        return new EngineTravelResult.TravelSuccess(Time, Fuel);
    }

    public bool SpeedDown(int distance)
    {
        double speed = Speed;
        for (int i = 0; i < distance; i++)
        {
            speed *= 0.9;
            Travel(1);
        }

        return speed > 0.1;
    }
}