namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class EngineC : Engine
{
    public EngineC()
        : base(20, 20)
    {
    }

    public override bool Move(int distance)
    {
        double time = distance / Speed;
        return Fuel.Use(time) >= 0;
    }
}