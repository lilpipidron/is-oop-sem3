namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public abstract class DeflectorDecorator : Model.Deflector.Deflector
{
    private readonly Model.Deflector.Deflector? _deflector;

    protected DeflectorDecorator(Model.Deflector.Deflector deflector)
    {
        _deflector = deflector;
    }
}