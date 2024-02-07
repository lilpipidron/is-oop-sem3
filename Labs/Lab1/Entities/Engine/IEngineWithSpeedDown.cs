using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public interface IEngineWithSpeedDown
{
    public EngineTravelResult TravelWithSpeedDown(int distance);
}