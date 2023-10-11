namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

public interface IFuel
{
    public double Amount { get; }
    public void Use(double time);
}