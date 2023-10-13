using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class EngineE : IEngine
{
    private const double Speed = 40;
    private const int StartCost = 50;
    public SimpleFuel Fuel { get; } = new();
    public double Time { get; private set; }

    public void Move(int distance)
    {
        double speed = Speed;
        speed += double.Exp(distance);
        double time = distance / speed;
        Time += time;
        Fuel.Use((time * 1.5) + StartCost);
    }
}