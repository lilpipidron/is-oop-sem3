using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

public abstract class Stability
{
    private int _healthPoint;

    protected Stability(int healthPoint)
    {
        _healthPoint = healthPoint;
    }

    public Result GetDamage(int damage)
    {
        if (_healthPoint <= 0)
        {
            return new ObstacleNotReflected();
        }

        _healthPoint -= damage;
        return new ObstacleReflected();
    }
}