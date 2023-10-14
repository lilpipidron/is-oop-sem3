using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class Deflector3 : IDeflector
{
    private const int SmallDamage = 10;
    private const int MediumDamage = 20;
    private double _healthPoints = 40;

    public Result GetDamage(double damage)
    {
        double damageReduce = 1;
        if (_healthPoints <= 0)
        {
            return new Result.ObstacleNotReflected(damage);
        }

        damageReduce = damage switch
        {
            > MediumDamage => 0.1,
            > SmallDamage and < MediumDamage => 0.4,
            _ => damageReduce,
        };

        damage *= damageReduce;

        if (damage > _healthPoints)
        {
            _healthPoints = 0;
            return new Result.ObstacleNotReflected(damage - _healthPoints);
        }

        _healthPoints -= damage;
        return new Result.ObstacleReflected(0);
    }
}