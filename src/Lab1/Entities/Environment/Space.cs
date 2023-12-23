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

    public EnvironmentResults TryOvercome(Ship.Ship ship)
    {
        EngineTravelResult travelResult = ship.Engine.Travel(_distance);
        if (travelResult is EngineTravelResult.TravelFailed)
        {
            return new EnvironmentResults.DestroyShip();
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