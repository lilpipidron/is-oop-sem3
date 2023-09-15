namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;

public class SimpleFuel : IFuel
{
    public SimpleFuel(int amount)
    {
        Amount = amount;
    }

    private int Amount { get; init; }

    public int Use(int distance)
    {
        throw new System.NotImplementedException();
    }
}