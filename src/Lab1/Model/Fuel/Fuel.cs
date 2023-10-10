namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

public abstract class Fuel
{
    public double Amount { get; private set; }

    public void Use(double time)
    {
        Amount += time;
    }
}