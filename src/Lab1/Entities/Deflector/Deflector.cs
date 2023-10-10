using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public abstract class Deflector
{
    protected Deflector()
    {
    }

    protected Deflector(int healthPoints, int smallDamage, int mediumDamage)
    {
        HealthPoints = healthPoints;
        SmallDamage = smallDamage;
        MediumDamage = mediumDamage;
    }

    protected Deflector(int healthPoints, int smallDamage)
    {
        HealthPoints = healthPoints;
        SmallDamage = smallDamage;
    }

    protected int SmallDamage { get; }

    protected int MediumDamage { get; }

    protected double HealthPoints { get; set; }

    public virtual bool PhotonDeflect()
    {
        return false;
    }

    public abstract Result GetDamage(int damage);
}