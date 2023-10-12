using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public abstract class DeflectorDecorator : IDeflector
{
    private readonly IDeflector _deflector;

    protected DeflectorDecorator(IDeflector deflector)
    {
        _deflector = deflector;
    }

    public Result GetDamage(int damage)
    {
        return _deflector.GetDamage(damage);
    }
}