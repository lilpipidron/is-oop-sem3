using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Stella : Ship
{
    private readonly EngineC _engineC;
    private readonly OmegaEngine _omegaEngine;
    private readonly Deflector1 _deflector;
    private readonly Stability1 _stability;

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

    public override IEnumerable<Fuel> FuelSpend()
    {
        var allFuel = new Collection<Fuel>
        {
            _engineC.Fuel,
            _omegaEngine.Fuel,
        };
        return allFuel;
    }

    public override void Move(Environment.Environment environment)
    {
        if (environment is IncreasedNebula)
        {
            _omegaEngine.Move(environment.JumpDistance);
        }
        else
        {
            _engineC.Move(environment.JumpDistance);
        }
    }

    public override double AllTime()
    {
        return _engineC.Time + _omegaEngine.Time;
    }
}