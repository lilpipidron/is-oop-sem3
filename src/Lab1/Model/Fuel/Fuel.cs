namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;

public abstract class Fuel
{
    protected Fuel(int amount)
    {
        Amount = amount;
    }

    public double Amount { get; set; }
    public abstract double Use(double time);
}