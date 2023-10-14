using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Avgur : Ship
{
    public Avgur(IDeflector deflector)
        : base(new EngineE())
    {
        JumpEngine = new AlphaEngine();
        Deflector = deflector;
        Stability = new Hull3();
    }
}