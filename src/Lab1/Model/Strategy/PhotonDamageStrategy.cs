using Itmo.ObjectOrientedProgramming.Lab1.Model.Damage;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Strategy;

public class PhotonDamageStrategy : IStrategy
{
    private const DamageType DeflectDamageType = DamageType.Photon;
    private int _charge = 3;

    public Result TakeDamage(Damage.Damage damage, double healthPoint)
    {
        if (damage.DamageType is not DeflectDamageType)
        {
            return new ObstacleNotReflected(damage);
        }

        if (_charge == 0)
        {
            return new CrewDied();
        }

        _charge--;
        return new ObstacleReflected(0);
    }
}