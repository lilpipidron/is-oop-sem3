using Itmo.ObjectOrientedProgramming.Lab1.Model.Damage;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class Meteorite : IObstacle
{
    private readonly Damage _damage = new(DamageType.Physical, 40);

    public Result DoDamage(Ship.Ship ship)
    {
        Result result = ship.GetDamage(_damage);
        return result is Result.ObstacleNotReflected ? new Result.DestroyShip() : result;
    }
}