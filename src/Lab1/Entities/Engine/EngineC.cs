namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class EngineC : Engine
{
    public EngineC()
        : base(20, 20)
    {
    }

    public override void Move(int distance)
    {
        double time = distance / Speed;
        Time += time;
        Fuel.Use(time + StartCost);
    }
}