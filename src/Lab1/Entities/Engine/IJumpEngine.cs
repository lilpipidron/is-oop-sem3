using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public interface IJumpEngine
{
    public JumpEngineTravelResult Travel(int distance);
}