using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class Deflector3 : IDeflector
{
    private const int SmallDamage = 10;
    private const int MediumDamage = 20;
    private double _healthPoints = 40;

    public Result GetDamage(int damage)
    {
        double damageReduce = 1;
        if (_healthPoints <= 0)
        {
            return new ObstacleNotReflected();
        }

        damageReduce = damage switch
        {
            > MediumDamage => 0.1,
            > SmallDamage and < MediumDamage => 0.4,
            _ => damageReduce,
        };

        if (damage * damageReduce > _healthPoints)
        {
            return new ObstacleNotReflected();
        }

        _healthPoints -= damage * damageReduce;
        return new ObstacleReflected();
    }
}