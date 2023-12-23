using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Meredian : Ship, IShipWithEmitter
{
    public Meredian(IDeflector deflector)
        : base(new EngineE())
    {
        Deflector = deflector;
        Stability = new Hull2();
    }
}