using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public abstract class Obstacle
{
    private readonly int _damage;

    protected Obstacle() { }

    protected Obstacle(int damage)
    {
        _damage = damage;
    }

    public virtual Result DoDamage(Ship.Ship ship)
    {
        Result result = ship.GetDamage(_damage);
        if (result is ObstacleNotReflected)
        {
            return new DestroyShip();
        }

        return result;
    }
}