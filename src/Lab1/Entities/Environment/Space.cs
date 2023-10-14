using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

public class Space : IEnvironment
{
    private readonly int _distance;
    private Collection<ISpaceObstacle> _obstacles;

    public Space(int distance, Collection<ISpaceObstacle> obstacles)
    {
        _distance = distance;
        _obstacles = obstacles;
    }

    public Result TryOvercome(Ship.Ship ship)
    {
        EngineTravelResult travelResult = ship.Engine.Travel(_distance);
        if (travelResult is EngineTravelResult.TravelFailed)
        {
            return new Result.DestroyShip();
        }

        if (_obstacles.Select(obstacle => obstacle.DoDamage(ship)).OfType<Result.ObstacleNotReflected>().Any())
        {
            return new Result.DestroyShip();
        }

        if (travelResult is EngineTravelResult.TravelSuccess travelSuccess)
        {
            return new Result.SuccessEnvironment(travelSuccess.Fuel, travelSuccess.Time);
        }

        return new Result.LostShip();
    }
}