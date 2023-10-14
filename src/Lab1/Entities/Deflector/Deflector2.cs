using Itmo.ObjectOrientedProgramming.Lab1.Model.Damage;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Strategy;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class Deflector2 : IDeflector
{
    private const int SmallDamage = 10;
    private readonly PhysDamageStrategy _strategy = new();
    private double _healthPoints = 100;

    public Result GetDamage(Damage damage)
    {
        double damageReduce = 1;
        if (_healthPoints <= 0)
        {
            return new Result.ObstacleNotReflected(damage);
        }

        if (damage.DamageAmount >= SmallDamage)
        {
            damageReduce = 0.3;
        }

        Damage newDamage = damage with { DamageAmount = damage.DamageAmount * damageReduce };

        if (damage.DamageAmount * damageReduce > _healthPoints)
        {
            return new Result.ObstacleNotReflected(newDamage with { DamageAmount = newDamage.DamageAmount - _healthPoints });
        }

        Result res = _strategy.TakeDamage(newDamage, _healthPoints);
        _healthPoints = res switch
        {
            Result.ObstacleReflected obstacleReflected => obstacleReflected.HealthPoint,
            Result.ObstacleNotReflected => 0,
            _ => _healthPoints,
        };

        return res;
    }
}