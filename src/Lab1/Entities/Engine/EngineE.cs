using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class EngineE : IEngine
{
    private const int StartCost = 50;
    public SimpleFuel Fuel { get; } = new();
    public double Time { get; private set; }

    public EngineTravelResult Travel(int distance)
    {
        double time = double.Log(distance + 1);
        Time = time;
        Fuel.Use(time + StartCost);
        return new EngineTravelResult.TravelSuccess(Time, Fuel);
    }
}