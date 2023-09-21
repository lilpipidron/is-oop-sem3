namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class GammaEngine : JumpEngine
{
    public GammaEngine(int fuelAmount, double jumpDistance)
        : base(fuelAmount, jumpDistance)
    {
    }

    public override bool Move(int distance)
    {
        return Fuel.Use(distance * distance) >= 0;
    }
}