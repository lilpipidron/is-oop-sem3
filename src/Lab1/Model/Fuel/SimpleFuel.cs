namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

public class SimpleFuel : IFuel
{
    public double Amount { get; private set; }

    public void Use(double time)
    {
        Amount += time;
    }
}