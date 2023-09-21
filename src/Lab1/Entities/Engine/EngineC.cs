namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class EngineC : Engine
{
    public EngineC(double speed, int startCost, int fuelAmount)
        : base(speed, startCost, fuelAmount)
    {
    }

    public override bool Move(int distance)
    {
        double time = distance / Speed;
        return Fuel.Use(time) >= 0;
    }
}