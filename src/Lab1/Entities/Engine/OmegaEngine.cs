namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class OmegaEngine : JumpEngine
{
    public OmegaEngine(int fuelAmount, double jumpDistance)
        : base(fuelAmount, jumpDistance)
    {
    }

    public override bool Move(int distance)
    {
        return Fuel.Use(distance * double.Log(distance)) >= 0;
    }
}