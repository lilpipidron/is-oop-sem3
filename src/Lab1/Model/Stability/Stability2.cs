using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

public class Stability2 : IStability
{
    private const int SmallDamage = 10;
    private double _healthPoint = 50;

    public Result GetDamage(int damage)
    {
        if (_healthPoint <= 0 || damage > _healthPoint)
        {
            return new ObstacleNotReflected();
        }

        double damageReduce = 1;
        if (damage > SmallDamage)
        {
            damageReduce = 0.4;
        }

        _healthPoint -= damage * damageReduce;
        return new ObstacleReflected();
    }
}