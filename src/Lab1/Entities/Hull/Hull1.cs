using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;

public class Hull1 : IHull
{
    private const int SmallDamage = 10;
    private double _healthPoint = 10;

    public Result HandleDamage(double damage)
    {
        if (_healthPoint <= 0)
        {
            return new Result.ObstacleNotReflected(damage);
        }

        double damageReduce = 1;
        if (damage > SmallDamage)
        {
            damageReduce = 0.4;
        }

        damage *= damageReduce;

        if (damage > _healthPoint)
        {
            _healthPoint = 0;
            return new Result.ObstacleNotReflected(damage - _healthPoint);
        }

        _healthPoint -= damage;
        return new Result.ObstacleReflected(_healthPoint);
    }
}