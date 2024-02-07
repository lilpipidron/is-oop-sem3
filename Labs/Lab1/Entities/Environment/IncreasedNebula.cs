using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

public class IncreasedNebula : IEnvironment
{
    private readonly int _distance;
    private readonly Collection<IIncreasedNebulaObstacle> _obstacles;

    public IncreasedNebula(int distance, Collection<IIncreasedNebulaObstacle> obstacles)
    {
        _distance = distance;
        _obstacles = obstacles;
    }

    public EnvironmentResults TryOvercome(Ship.Ship ship)
    {
        if (ship.JumpEngine is null)
        {
            return new EnvironmentResults.LostShip();
        }

        JumpEngineTravelResult travelResult = ship.JumpEngine.Travel(_distance);
        if (_obstacles.Select(obs => obs.DoDamage(ship)).OfType<ObstacleResults.ObstacleNotReflected>().Any())
        {
            return new EnvironmentResults.CrewDied();
        }

        if (travelResult is JumpEngineTravelResult.TravelSuccess travelSuccess)
        {
            return new EnvironmentResults.SuccessEnvironment(travelSuccess.Fuel, travelSuccess.Time);
        }

        return new EnvironmentResults.LostShip();
    }
}