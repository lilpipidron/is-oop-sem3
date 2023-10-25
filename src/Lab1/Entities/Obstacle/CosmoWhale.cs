using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class CosmoWhale : INitrineNebulaObstacle
{
    private readonly int _damage = 400;

    public CosmoWhale(int amount)
    {
        _damage *= amount;
    }

    public ObstacleResults DoDamage(Ship.Ship ship)
    {
        if (ship is IShipWithEmitter)
        {
            return new ObstacleResults.ObstacleReflected(0);
        }

        ObstacleResults result = ship.HandleDamage(_damage);
        return result;
    }
}