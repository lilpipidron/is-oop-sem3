using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Avgur
{
    public Avgur()
    {
        EngineE = new EngineE();
        AlphaEngine = new AlphaEngine();
        Deflector = new Deflector3();
        Stability = new Stability3();
        DoW = 40;
    }

    private EngineE EngineE { get; set; }
    private AlphaEngine AlphaEngine { get; set; }
    private Deflector3 Deflector { get; set; }
    private Stability3 Stability { get; set; }
    private int DoW { get; set; }
}