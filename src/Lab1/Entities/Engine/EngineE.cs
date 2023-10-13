using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class EngineE : IEngine
{
    private const int StartCost = 50;
    public SimpleFuel Fuel { get; } = new();
    public double Time { get; private set; }

    public void Move(int distance)
    {
        double time = double.Log(distance + 1);
        Time += time;
        Fuel.Use(time + StartCost);
    }
}