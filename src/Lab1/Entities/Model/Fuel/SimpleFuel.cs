namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;

public class SimpleFuel : IFuel
{
    public SimpleFuel(int amount)
    {
        Amount = amount;
    }

    private int Amount { get; set; }

    public int Use(double time)
    {
        throw new System.NotImplementedException();
    }
}