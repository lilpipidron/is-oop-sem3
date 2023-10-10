using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class Deflector3 : Deflector
{
    public Deflector3()
        : base(400, 10, 20)
    {
    }

    public override Result GetDamage(int damage)
    {
        double damageReduce = 1;
        if (HealthPoints <= 0)
        {
            return new ObstacleNotReflected();
        }

        if (damage > MediumDamage)
        {
            damageReduce = 0.1;
        }

        if (damage > SmallDamage && damage < MediumDamage)
        {
            damageReduce = 0.4;
        }

        if (damage * damageReduce > HealthPoints)
        {
            return new ObstacleNotReflected();
        }

        HealthPoints -= damage * damageReduce;
        return new ObstacleReflected();
    }
}