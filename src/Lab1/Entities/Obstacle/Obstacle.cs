using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public abstract class Obstacle
{
    private int _dow;
    protected Obstacle() { }

    protected Obstacle(int dw, int damage)
    {
        _dow = dw;
        Damage = damage;
    }

    public int Damage { get; private set; }

    public virtual Result DoDamage(Ship.Ship ship)
    {
        Result result = ship.GetDamage(Damage);
        if (result is ObstacleNotReflected)
        {
            return new DestroyShip();
        }

        return result;
    }
}