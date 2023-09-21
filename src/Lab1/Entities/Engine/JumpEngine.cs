using Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public abstract class JumpEngine
{
    protected JumpEngine(int fuelAmount, double jumpDistance)
    {
        Fuel = new SpecialFuel(fuelAmount);
        JumpDistance = jumpDistance;
    }

    protected SpecialFuel Fuel { get; init; }
    protected double JumpDistance { get; init; }

    public abstract bool Move(int distance);
}