using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class EngineC : IEngine
{
    private const double Speed = 20;
    private const int StartCost = 20;

    public double Time { get; private set; }
    public SimpleFuel Fuel { get; } = new();

    public void Move(int distance)
    {
        double time = distance / Speed;
        Time += time;
        Fuel.Use(time + StartCost);
    }

    public bool SpeedDown(int distance)
    {
        double speed = Speed;
        for (int i = 0; i < distance; i++)
        {
            speed *= 0.9;
            Move(1);
        }

        return speed > 0.1;
    }
}