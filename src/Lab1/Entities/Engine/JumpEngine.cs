using Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public abstract class JumpEngine
{
    protected JumpEngine(int fuelAmount)
    {
        Fuel = new SpecialFuel(fuelAmount);
    }

    private SpecialFuel Fuel { get; init; }
}