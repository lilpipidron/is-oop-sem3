using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Vaklas : Ship
{
    public Vaklas(IDeflector deflector)
        : base(new EngineE())
    {
        JumpEngine = new GammaEngine();
        Deflector = deflector;
        Stability = new Hull2();
    }
}