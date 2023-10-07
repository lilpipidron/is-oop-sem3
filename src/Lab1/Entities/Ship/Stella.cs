using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Stella : Ship
{
    private readonly Engine.Engine _engineC;
    private readonly JumpEngine _omegaEngine;
    private readonly Model.Deflector.Deflector _deflector;
    private readonly Stability _stability;

    public Stella()
    {
        _engineC = new EngineC();
        _omegaEngine = new OmegaEngine();
        JumpDistance = _omegaEngine.JumpDistance;
        _deflector = new Deflector1();
        _stability = new Stability1();
        DoW = 20;
    }

    private int DoW { get; set; }

    public override Obstacle.Obstacle? GetDamage(Obstacle.Obstacle obstacle)
    {
        Obstacle.Obstacle? obs = _deflector.GetDamage(obstacle);
        return _stability.GetDamage(obs);
    }
}