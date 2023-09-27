using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Avgur : Ship
{
    public Avgur()
    {
        EngineE = new EngineE();
        JumpEngine = new AlphaEngine();
        JumpDistance = JumpEngine.JumpDistance;
        Deflector = new Deflector3();
        Stability = new Stability3();
        DoW = 40;
    }

    private EngineE EngineE { get; set; }
    private AlphaEngine JumpEngine { get; set; }
    private Deflector3 Deflector { get; set; }
    private Stability3 Stability { get; set; }
    private int DoW { get; set; }

    public void AddPhotonDeflector()
    {
        Deflector.AddPhotonDeflector();
    }

    public override Obstacle.Obstacle? GetDamage(Obstacle.Obstacle obstacle)
    {
        Obstacle.Obstacle? obs = Deflector.GetDamage(obstacle);
        return Stability.GetDamage(obs);
    }
}