using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Vaklas : Ship
{
    public Vaklas()
    {
        Engine = new EngineE();
        JumpEngine = new GammaEngine();
        JumpDistance = JumpEngine.JumpDistance;
        Deflector = new Deflector1();
        Stability = new Stability2();
        DoW = 30;
    }

    private int DoW { get; set; }
}