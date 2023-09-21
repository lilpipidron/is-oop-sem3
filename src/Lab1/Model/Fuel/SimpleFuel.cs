namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;

public class SimpleFuel : Fuel
{
    public SimpleFuel(double amount)
    {
        Amount = amount;
    }

    private double Amount { get; set; }

    public override double Use(double time)
    {
        Amount -= time * 1.2;
        return Amount;
    }
}