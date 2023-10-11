using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Avgur : Ship
{
    public Avgur()
    {
        Engine = new EngineE();
        JumpEngine = new AlphaEngine();
        JumpDistance = JumpEngine.JumpDistance;
        Deflector = new Deflector3();
        Stability = new Stability3();
    }
}