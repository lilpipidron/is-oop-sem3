namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;

public abstract class Fuel
{
    public double Amount { get; protected set; }

    public abstract void Use(double time);
}