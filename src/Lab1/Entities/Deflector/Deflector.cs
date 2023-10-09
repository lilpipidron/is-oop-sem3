using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public abstract class Deflector
{
    private int _healthPoints;

    protected Deflector()
    {
    }

    protected Deflector(int healthPoints)
    {
        _healthPoints = healthPoints;
    }

    public virtual bool PhotonDeflect()
    {
        return false;
    }

    public Result GetDamage(int damage)
    {
        if (_healthPoints <= 0)
        {
            return new ObstacleNotReflected();
        }

        _healthPoints -= damage;
        return new ObstacleReflected();
    }
}