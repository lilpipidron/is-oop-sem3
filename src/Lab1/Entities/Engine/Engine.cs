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

    protected double Speed { get; set; }

    protected int StartCost { get; set; }

    protected SimpleFuel Fuel { get; set; }

    public abstract bool Move(int distance);

    protected void Refill(int fuelAmount)
    {
        Fuel.Fill(fuelAmount);
    }
}