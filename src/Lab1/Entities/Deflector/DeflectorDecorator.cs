using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public abstract class DeflectorDecorator : IDeflector
{
    private readonly IDeflector _deflector;

    protected DeflectorDecorator(IDeflector deflector)
    {
        _deflector = deflector;
    }

    public virtual ObstacleResults GetDamage(double damage)
    {
        return _deflector.GetDamage(damage);
    }
}