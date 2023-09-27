namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;

public class SpecialFuel : Fuel
{
    public override void Use(double time)
    {
        Amount += time;
    }
}