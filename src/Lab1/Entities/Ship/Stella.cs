using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Stella : Ship
{
    public Stella(IDeflector deflector)
        : base(new EngineC())
    {
        JumpEngine = new OmegaEngine();
        Deflector = deflector;
        Stability = new Hull1();
    }
}