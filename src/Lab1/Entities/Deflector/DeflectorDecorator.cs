namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Deflector;

public abstract class DeflectorDecorator : Deflector
{
    private readonly Deflector? _deflector;

    protected DeflectorDecorator(Deflector deflector)
    {
        _deflector = deflector;
    }
}