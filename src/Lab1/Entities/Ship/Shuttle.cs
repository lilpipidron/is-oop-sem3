using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Shuttle : Ship
{
    private readonly EngineC _engine;
    private readonly Stability1 _stability;

    public Shuttle()
    {
        _engine = new EngineC();
        _stability = new Stability1();
        DoW = 20;
    }

    private int DoW { get; set; }

    public override Obstacle.Obstacle? GetDamage(Obstacle.Obstacle obstacle)
    {
        return _stability.GetDamage(obstacle);
    }

    public override Collection<Fuel> FuelSpend()
    {
        var allFuel = new Collection<Fuel>();
        allFuel.Add(_engine.Fuel);
        return allFuel;
    }

    public override void Move(Environment environment)
    {
        if (environment is NitrineNebula)
        {
            _engine.Move(environment.JumpDistance * 100);
            return;
        }

        _engine.Move(environment.JumpDistance);
    }
}