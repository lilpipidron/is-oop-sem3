using Itmo.ObjectOrientedProgramming.Lab1.Model.Damage;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

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
        if (ship.Emitter)
        {
            return new ObstacleReflected(0);
        }

        Result result = ship.GetDamage(_damage);
        return result is ObstacleNotReflected ? new DestroyShip() : result;
    }
}