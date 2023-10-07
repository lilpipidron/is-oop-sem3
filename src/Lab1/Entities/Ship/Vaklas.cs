using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Vaklas : Ship
{
    private readonly Engine.Engine _engineE;
    private readonly JumpEngine _gammaEngine;
    private readonly Stability _stability;
    private Model.Deflector.Deflector _deflector;

    public Vaklas()
    {
        _engineE = new EngineE();
        _gammaEngine = new GammaEngine();
        JumpDistance = _gammaEngine.JumpDistance;
        _deflector = new Deflector1();
        _stability = new Stability2();
        DoW = 30;
    }

    private int DoW { get; set; }

    public override Obstacle.Obstacle? GetDamage(Obstacle.Obstacle obstacle)
    {
        Obstacle.Obstacle? obs = _deflector.GetDamage(obstacle);
        return _stability.GetDamage(obs);
    }
}