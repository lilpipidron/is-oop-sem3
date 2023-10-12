using Itmo.ObjectOrientedProgramming.Lab1.Model.Strategy;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

public class Stability2 : IStability
{
    private const int SmallDamage = 10;
    private readonly PhysDamageStrategy _strategy = new();
    private double _healthPoint = 50;

    public Result GetDamage(Damage.Damage damage)
    {
        if (_healthPoint <= 0 || damage.DamageAmount > _healthPoint)
        {
            return new ObstacleNotReflected(damage);
        }

        double damageReduce = 1;
        if (damage.DamageAmount > SmallDamage)
        {
            damageReduce = 0.4;
        }

        Damage.Damage newDamage = damage with { DamageAmount = damage.DamageAmount * damageReduce };

        Result res = _strategy.TakeDamage(newDamage, _healthPoint);
        if (res is ObstacleNotReflected)
        {
            _healthPoint = 0;
        }

        return res;
    }
}