namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;

public class SpecialFuel : IFuel
{
    public SpecialFuel(int fuelAmount)
    {
        Amout = fuelAmount;
    }

    private int Amout { get; set; }

    public int Use(int distance)
    {
        throw new System.NotImplementedException();
    }
}