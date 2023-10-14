using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

public interface IEnvironment
{
    public Result TryOvercome(Ship.Ship ship);
}