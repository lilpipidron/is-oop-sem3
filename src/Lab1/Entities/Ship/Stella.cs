using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Stella : Ship
{
    public Stella()
    {
        Engine = new EngineC();
        JumpEngine = new OmegaEngine();
        JumpDistance = JumpEngine.JumpDistance;
        Deflector = new Deflector1();
        Stability = new Stability1();
        DoW = 20;
    }

    private int DoW { get; set; }
}