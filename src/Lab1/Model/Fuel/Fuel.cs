namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;

public abstract class Fuel
{
    public double Amount { get; set; }

    public abstract double Use(double time);

    public void Fill(double amount)
    {
        Amount += amount;
    }
}