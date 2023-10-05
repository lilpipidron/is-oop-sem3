namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class GammaEngine : JumpEngine
{
    public GammaEngine()
        : base(30)
    {
    }

    public override void Move(int distance)
    {
        Time += JumpDistance / distance;
        Fuel.Use(distance * distance);
    }
}