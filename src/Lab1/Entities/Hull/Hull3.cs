using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Strategy;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Stability;

public class Hull3 : IHull
{
    private const int SmallDamage = 10;
    private readonly PhysDamageStrategy _strategy = new();
    private double _healthPoint = 200;

    public Result GetDamage(Model.Damage.Damage damage)
    {
        if (_healthPoint <= 0 || damage.DamageAmount > _healthPoint)
        {
            return new Result.ObstacleNotReflected(damage);
        }

        double damageReduce = 1;
        if (damage.DamageAmount > SmallDamage)
        {
            damageReduce = 0.4;
        }

        Model.Damage.Damage newDamage = damage with { DamageAmount = damage.DamageAmount * damageReduce };

        Result res = _strategy.TakeDamage(newDamage, _healthPoint);
        if (res is Result.ObstacleNotReflected)
        {
            _healthPoint = 0;
        }

        return res;
    }
}