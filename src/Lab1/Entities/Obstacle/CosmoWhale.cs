using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Damage;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class CosmoWhale : IObstacle
{
    private readonly Damage _damage;

    public CosmoWhale(int amount)
    {
        _damage = new Damage(DamageType.Physical, 400 * amount);
    }

    public Result DoDamage(Ship.Ship ship)
    {
        if (ship is IShipWithEmitter)
        {
            return new Result.ObstacleReflected(0);
        }

        Result result = ship.GetDamage(_damage);
        return result is Result.ObstacleNotReflected ? new Result.DestroyShip() : result;
    }
}