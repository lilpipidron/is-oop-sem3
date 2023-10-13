using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class AlphaEngine : IJumpEngine
{
    public double JumpDistance { get; init; } = 10;
    public SpecialFuel Fuel { get; init; } = new();
    public double Time { get; private set; }

    public void Move(int distance)
    {
        Time += JumpDistance / distance;
        Fuel.Use(distance);
    }
}