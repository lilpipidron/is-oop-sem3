using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public interface IEngine
{
    public EngineTravelResult Travel(int distance);
}