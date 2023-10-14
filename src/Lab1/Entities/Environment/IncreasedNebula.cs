using System.Collections.ObjectModel;
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

    public Result TryOvercome(Ship.Ship ship)
    {
        if (ship.JumpEngine is null)
        {
            return new Result.LostShip();
        }

        JumpEngineTravelResult travelResult = ship.JumpEngine.Travel(_distance);
        foreach (IIncreasedNebulaObstacle obs in _obstacles)
        {
            Result obstacleResult = obs.DoDamage(ship);
            if (obstacleResult is not Result.ObstacleReflected)
            {
                return obstacleResult;
            }
        }

        if (travelResult is JumpEngineTravelResult.TravelSuccess travelSuccess)
        {
            return new Result.SuccessEnvironment(travelSuccess.Fuel, travelSuccess.Time);
        }

        return new Result.LostShip();
    }
}