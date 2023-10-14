using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

public class NitrineNebula : IEnvironment
{
    private readonly Collection<INitrineNebulaObstacle> _obstacles;
    private readonly int _distance;

    public NitrineNebula(int distance, Collection<INitrineNebulaObstacle> obstacles)
    {
        _distance = distance;
        _obstacles = obstacles;
    }

    public Result TryOvercome(Ship.Ship ship)
    {
        if (ship.Engine is IEngineWithSpeedDown engineWithSpeedDown)
        {
            if (engineWithSpeedDown.SpeedDown(_distance) is false)
            {
                return new Result.LostShip();
            }
        }

        EngineTravelResult travelResult = ship.Engine.Travel(_distance);
        if (travelResult is EngineTravelResult.TravelFailed)
        {
            return new Result.LostShip();
        }

        foreach (INitrineNebulaObstacle obstacle in _obstacles)
        {
            Result res = obstacle.DoDamage(ship);
            if (res is not Result.ObstacleReflected)
            {
                return res;
            }
        }

        if (travelResult is EngineTravelResult.TravelSuccess travelSuccess)
        {
            return new Result.SuccessEnvironment(travelSuccess.Fuel, travelSuccess.Time);
        }

        return new Result.LostShip();
    }
}