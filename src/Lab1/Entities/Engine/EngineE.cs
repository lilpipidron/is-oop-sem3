namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class EngineE : Engine
{
    public EngineE(double speed, int fuelAmount)
        : base(speed, fuelAmount)
    {
    }

    public override bool Move(int distance)
    {
        Speed = double.Exp(distance);
        double time = distance / Speed;
        return Fuel.Use(time * 1.5) > 0;
    }
}