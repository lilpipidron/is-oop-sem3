using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public interface IJumpEngine
{
    public double JumpDistance { get; init; }
    public SpecialFuel Fuel { get; init; }
    public double Time { get; }
    public void Move(int distance);
}