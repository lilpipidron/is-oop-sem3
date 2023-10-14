namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

public class SpecialFuel : IFuel
{
    public SpecialFuel(double amount)
    {
        Amount = amount;
    }

    public double Amount { get; }
}