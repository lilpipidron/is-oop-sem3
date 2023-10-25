using System.Collections.ObjectModel;
using System.Linq;
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

    public EnvironmentResults TryOvercome(Ship.Ship ship)
    {
        if (ship.Engine is IEngineWithSpeedDown engineWithSpeedDown)
        {
            if (engineWithSpeedDown.SpeedDown(_distance) is false)
            {
                return new EnvironmentResults.LostShip();
            }
        }

        EngineTravelResult travelResult = ship.Engine.Travel(_distance);
        if (travelResult is EngineTravelResult.TravelFailed)
        {
            return new EnvironmentResults.LostShip();
        }

        if (_obstacles.Select(obstacle => obstacle.DoDamage(ship)).OfType<ObstacleResults.ObstacleNotReflected>().Any())
        {
            return new EnvironmentResults.DestroyShip();
        }

        if (travelResult is EngineTravelResult.TravelSuccess travelSuccess)
        {
            return new EnvironmentResults.SuccessEnvironment(travelSuccess.Fuel, travelSuccess.Time);
        }

        return new EnvironmentResults.LostShip();
    }
}