using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

public abstract class Stability
{
    private readonly int _smallDamage;
    private double _healthPoint;

    protected Stability(int healthPoint, int smallDamage)
    {
        _healthPoint = healthPoint;
        _smallDamage = smallDamage;
    }

    public Result GetDamage(int damage)
    {
        if (_healthPoint <= 0 || damage > _healthPoint)
        {
            return new ObstacleNotReflected();
        }

        double damageReduce = 1;
        if (damage > _smallDamage)
        {
            damageReduce = 0.4;
        }

        _healthPoint -= damage * damageReduce;
        return new ObstacleReflected();
    }
}

/*
-
0.4
0.4
*/