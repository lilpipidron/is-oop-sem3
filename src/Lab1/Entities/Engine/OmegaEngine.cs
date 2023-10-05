namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class OmegaEngine : JumpEngine
{
    public OmegaEngine()
        : base(20)
    {
    }

    public override void Move(int distance)
    {
        Time += JumpDistance / distance;
        Fuel.Use(distance * double.Log(distance));
    }
}