namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

public class SimpleFuel : Lab1.Model.Fuel.Fuel
{
    public override void Use(double time)
    {
        Amount += time;
    }
}