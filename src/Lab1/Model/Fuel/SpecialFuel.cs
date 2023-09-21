namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;

public class SpecialFuel : Fuel
{
    public SpecialFuel(int fuelAmount)
    {
        Amout = fuelAmount;
    }

    private int Amout { get; set; }

    public override double Use(double time)
    {
        throw new System.NotImplementedException();
    }
}