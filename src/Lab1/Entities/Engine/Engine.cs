using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

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
    public double Time { get; protected set; }
    protected double Speed { get; set; }
    protected int StartCost { get; }

    public abstract void Move(int distance);

    public virtual bool SpeedDown(int distance)
    {
        return true;
    }
}