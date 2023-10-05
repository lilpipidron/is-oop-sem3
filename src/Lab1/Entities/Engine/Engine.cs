using Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public abstract class Engine
{
    protected Engine(double speed, int startCost)
    {
        Speed = speed;
        StartCost = startCost;
        Fuel = new SimpleFuel();
    }

    public SimpleFuel Fuel { get; private set; }
    protected double Speed { get; set; }
    protected int StartCost { get; set; }
    protected double Time { get; set; }

    public abstract void Move(int distance);
}