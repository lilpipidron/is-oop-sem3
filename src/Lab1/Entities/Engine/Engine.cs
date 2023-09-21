using Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public abstract class Engine
{
    protected Engine(double speed, int startCost, int fuelAmount)
    {
        Speed = speed;
        Fuel = new SimpleFuel(fuelAmount - startCost);
    }

    protected double Speed { get; set; }
    protected SimpleFuel Fuel { get; set; }

    public abstract bool Move(int distance);
}