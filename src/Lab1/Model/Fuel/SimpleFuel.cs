namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;

public class SimpleFuel : Fuel
{
    public override void Use(double time)
    {
        Amount += time;
    }
}