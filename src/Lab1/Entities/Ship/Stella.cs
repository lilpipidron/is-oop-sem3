using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Stella : Ship
{
    public Stella()
    {
        EngineC = new EngineC();
        OmegaEngine = new OmegaEngine();
        Deflector = new Deflector1();
        Stability = new Stability1();
        DoW = 20;
    }

    private EngineC EngineC { get; set; }
    private OmegaEngine OmegaEngine { get; set; }
    private Deflector1 Deflector { get; set; }
    private Stability1 Stability { get; set; }
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