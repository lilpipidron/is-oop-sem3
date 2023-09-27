namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class EngineE : Engine
{
    public EngineE()
        : base(40, 20)
    {
    }

    public override void Move(int distance)
    {
        Speed = double.Exp(distance);
        double time = distance / Speed;
        Fuel.Use((time * 1.5) + StartCost);
    }
}