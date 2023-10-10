using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class Deflector2 : Deflector
{
    public Deflector2()
        : base(100, 10)
    {
    }

    public override Result GetDamage(int damage)
    {
        double damageReduce = 1;
        if (HealthPoints <= 0)
        {
            return new ObstacleNotReflected();
        }

        if (damage >= SmallDamage)
        {
            damageReduce = 0.3;
        }

        if (damage * damageReduce > HealthPoints)
        {
            return new ObstacleNotReflected();
        }

        HealthPoints -= damage * damageReduce;
        return new ObstacleReflected();
    }
}