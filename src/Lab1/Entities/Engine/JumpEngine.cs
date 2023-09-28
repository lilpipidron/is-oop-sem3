using Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public abstract class JumpEngine
{
    protected JumpEngine(double jumpDistance)
    {
        Fuel = new SpecialFuel();
        JumpDistance = jumpDistance;
    }

    public double JumpDistance { get; private set; }
    public SpecialFuel Fuel { get; init; }
    public abstract void Move(int distance);
}