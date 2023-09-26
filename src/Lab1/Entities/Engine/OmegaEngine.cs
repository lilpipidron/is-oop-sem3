namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class OmegaEngine : JumpEngine
{
    public OmegaEngine()
        : base(20)
    {
    }

    public override bool Move(int distance)
    {
        return Fuel.Use(distance * double.Log(distance)) >= 0;
    }
}