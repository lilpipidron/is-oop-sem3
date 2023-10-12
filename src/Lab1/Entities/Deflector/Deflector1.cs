using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class Deflector1 : IDeflector
{
    private const int SmallDamage = 10;
    private double _healthPoints = 20;

    public Result GetDamage(int damage)
    {
        double damageReduce = 1;
        if (_healthPoints <= 0)
        {
            return new ObstacleNotReflected();
        }

        if (damage > SmallDamage)
        {
            damageReduce = 0.5;
        }

        if (damage * damageReduce > _healthPoints)
        {
            return new ObstacleNotReflected();
        }

        _healthPoints -= damage * damageReduce;
        return new ObstacleReflected();
    }
}