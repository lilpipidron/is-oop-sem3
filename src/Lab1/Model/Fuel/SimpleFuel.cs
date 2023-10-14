namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

public class SimpleFuel : IFuel
{
    public SimpleFuel(double amount)
    {
        Amount = amount;
    }

    public double Amount { get; }
}