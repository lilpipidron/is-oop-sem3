using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Stability;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Meredian : Ship
{
    public Meredian()
    {
        Engine = new EngineE();
        Deflector = new Deflector2();
        Stability = new Stability2();
        Emitter = true;
    }
}