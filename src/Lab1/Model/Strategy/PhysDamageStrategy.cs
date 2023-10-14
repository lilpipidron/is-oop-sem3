using Itmo.ObjectOrientedProgramming.Lab1.Model.Damage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Strategy;

public class PhysDamageStrategy : IStrategy
{
    private const DamageType DeflectDamageType = DamageType.Physical;

    public Result.Result TakeDamage(Damage.Damage damage, double healthPoint)
    {
        if (damage.DamageType is not DeflectDamageType)
        {
            return new Result.Result.CrewDied();
        }

        if (damage.DamageAmount > healthPoint)
        {
            return new Result.Result.ObstacleNotReflected(damage with { DamageAmount = damage.DamageAmount - healthPoint });
        }

        return new Result.Result.ObstacleReflected(healthPoint - damage.DamageAmount);
    }
}