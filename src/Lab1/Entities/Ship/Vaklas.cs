using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Vaklas
{
    public Vaklas()
    {
        EngineE = new EngineE();
        GammaEngine = new GammaEngine();
        Deflector = new Deflector1();
        Stability = new Stability2();
        DoW = 30;
    }

    private EngineE EngineE { get; set; }
    private GammaEngine GammaEngine { get; set; }
    private Deflector1 Deflector { get; set; }
    private Stability2 Stability { get; set; }
    private int DoW { get; set; }
}