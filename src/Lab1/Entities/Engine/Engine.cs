using Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public abstract class Engine
{
    protected Engine(double speed, int fuelAmount)
    {
        Speed = speed;
        Fuel = new SimpleFuel(fuelAmount);
    }

    private double Speed { get; init; }
    private SimpleFuel Fuel { get; init; }

    public abstract bool Move(int distace);
}