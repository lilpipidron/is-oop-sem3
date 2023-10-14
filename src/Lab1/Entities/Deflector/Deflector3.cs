using Itmo.ObjectOrientedProgramming.Lab1.Model.Damage;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Strategy;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class Deflector3 : IDeflector
{
    private const int SmallDamage = 10;
    private const int MediumDamage = 20;
    private readonly PhysDamageStrategy _strategy = new();
    private double _healthPoints = 40;

    public Result GetDamage(Damage damage)
    {
        double damageReduce = 1;
        if (_healthPoints <= 0)
        {
            return new Result.ObstacleNotReflected(damage);
        }

        damageReduce = damage.DamageAmount switch
        {
            > MediumDamage => 0.1,
            > SmallDamage and < MediumDamage => 0.4,
            _ => damageReduce,
        };

        Damage newDamage = damage with { DamageAmount = damage.DamageAmount * damageReduce };

        if (newDamage.DamageAmount > _healthPoints)
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