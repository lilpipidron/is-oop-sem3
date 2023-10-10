using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public abstract class DeflectorDecorator : Deflector
{
    private readonly Deflector _deflector;

    protected DeflectorDecorator(Deflector deflector)
    {
        _deflector = deflector;
    }

    public override Result GetDamage(int damage)
    {
        return _deflector.GetDamage(damage);
    }
}