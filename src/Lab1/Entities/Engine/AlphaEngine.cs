namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class AlphaEngine : JumpEngine
{
    public AlphaEngine()
        : base(10)
    {
    }

    public override bool Move(int distance)
    {
        return Fuel.Use(distance) >= 0;
    }
}