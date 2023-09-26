using Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public abstract class JumpEngine
{
    protected JumpEngine(double jumpDistance)
    {
        Fuel = new SpecialFuel();
        JumpDistance = jumpDistance;
    }

    protected SpecialFuel Fuel { get; init; }
    protected double JumpDistance { get; init; }

    public void Refill(int amount)
    {
        Fuel.Fill(amount);
    }

    public abstract bool Move(int distance);
}