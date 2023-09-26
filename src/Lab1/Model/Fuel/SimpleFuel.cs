namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;

public class SimpleFuel : Fuel
{
    public override double Use(double time)
    {
        Amount -= time * 1.2;
        return Amount;
    }
}