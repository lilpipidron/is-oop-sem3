namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public abstract class DeflectorDecorator : Deflector
{
    private readonly Deflector? _deflector;

    protected DeflectorDecorator(Deflector deflector)
    {
        _deflector = deflector;
    }
}