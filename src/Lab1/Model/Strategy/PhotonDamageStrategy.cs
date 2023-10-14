using Itmo.ObjectOrientedProgramming.Lab1.Model.Damage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Strategy;

public class PhotonDamageStrategy : IStrategy
{
    private const DamageType DeflectDamageType = DamageType.Photon;
    private int _charge = 3;

    public Result.Result TakeDamage(Damage.Damage damage, double healthPoint)
    {
        if (damage.DamageType is not DeflectDamageType)
        {
            return new Result.Result.ObstacleNotReflected(damage);
        }

        if (_charge == 0)
        {
            return new Result.Result.CrewDied();
        }

        _charge--;
        return new Result.Result.ObstacleReflected(0);
    }
}