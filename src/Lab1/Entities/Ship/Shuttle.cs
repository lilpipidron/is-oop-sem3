using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Shuttle : Ship
{
    private readonly Engine.Engine _engine = new EngineC();
    private readonly Stability _stability = new Stability1();

    private int DoW { get; set; } = 20;

    public override Obstacle.Obstacle? GetDamage(Obstacle.Obstacle obstacle)
    {
        return _stability.GetDamage(obstacle);
    }

    public override IEnumerable<Fuel> FuelSpend()
    {
        var allFuel = new Collection<Fuel> { _engine.Fuel };
        return allFuel;
    }

    public override void Move(Environment.Environment environment)
    {
        if (environment is NitrineNebula)
        {
            _engine.Move(environment.JumpDistance * 100);
            return;
        }

        _engine.Move(environment.JumpDistance);
    }

    public override double AllTime()
    {
        return _engine.Time;
    }
}