namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

public class SpecialFuel : Lab1.Model.Fuel.Fuel
{
    public override void Use(double time)
    {
        Amount += time;
    }
}