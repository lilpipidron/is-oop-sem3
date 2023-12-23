using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;

public class Hull3 : IHull
{
    private const int SmallDamage = 10;
    private double _healthPoint = 200;

    public ObstacleResults HandleDamage(double damage)
    {
        if (_healthPoint <= 0)
        {
            return new ObstacleResults.ObstacleNotReflected(damage);
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
            return new ObstacleResults.ObstacleNotReflected(damage - _healthPoint);
        }

        _healthPoint -= damage;
        return new ObstacleResults.ObstacleReflected(_healthPoint);
    }
}