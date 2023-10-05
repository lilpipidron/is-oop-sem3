namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class AlphaEngine : JumpEngine
{
    public AlphaEngine()
        : base(10)
    {
    }

    public override void Move(int distance)
    {
        Time += JumpDistance / distance;
        Fuel.Use(distance);
    }
}