using Itmo.ObjectOrientedProgramming.Lab1.Model.Damage;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class Asteroid : IObstacle
{
    private readonly Damage _damage = new(DamageType.Physical, 10);

    public Result DoDamage(Ship.Ship ship)
    {
        Result result = ship.GetDamage(_damage);
        return result is ObstacleNotReflected ? new DestroyShip() : result;
    }
}