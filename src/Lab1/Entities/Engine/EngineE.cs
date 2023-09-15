namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class EngineE : Engine
{
    public EngineE(double speed, int fuelAmount)
        : base(speed, fuelAmount)
    {
    }

    public override bool Move(int distace)
    {
        throw new System.NotImplementedException();
    }
}