namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class GammaEngine : JumpEngine
{
    public GammaEngine()
        : base(30)
    {
    }

    public override bool Move(int distance)
    {
        return Fuel.Use(distance * distance) >= 0;
    }
}