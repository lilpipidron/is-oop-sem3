using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public interface IEngine
{
    public SimpleFuel Fuel { get; }
    public double Time { get; }
    public void Move(int distance);
}