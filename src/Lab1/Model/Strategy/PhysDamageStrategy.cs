using Itmo.ObjectOrientedProgramming.Lab1.Model.Damage;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Strategy;

public class PhysDamageStrategy : IStrategy
{
    private const DamageType DeflectDamageType = DamageType.Physical;

    public Result TakeDamage(Damage.Damage damage, double healthPoint)
    {
        if (damage.DamageType is not DeflectDamageType)
        {
            return new CrewDied();
        }

        if (damage.DamageAmount > healthPoint)
        {
            return new ObstacleNotReflected(damage with { DamageAmount = damage.DamageAmount - healthPoint });
        }

        return new ObstacleReflected(healthPoint - damage.DamageAmount);
    }
}