using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Avgur : Ship
{
    private readonly EngineE _engineE;
    private readonly AlphaEngine _jumpEngine;
    private readonly Deflector3 _deflector;
    private readonly Stability3 _stability;

    public Avgur()
    {
        _engineE = new EngineE();
        _jumpEngine = new AlphaEngine();
        JumpDistance = _jumpEngine.JumpDistance;
        _deflector = new Deflector3();
        _stability = new Stability3();
        DoW = 40;
    }

    private int DoW { get; set; }

    public void AddPhotonDeflector()
    {
        _deflector.AddPhotonDeflector();
    }

    public override Obstacle.Obstacle? GetDamage(Obstacle.Obstacle obstacle)
    {
        Obstacle.Obstacle? obs = _deflector.GetDamage(obstacle);
        return _stability.GetDamage(obs);
    }

    public override Collection<Fuel> FuelSpend()
    {
        var allFuel = new Collection<Fuel>();
        allFuel.Add(_engineE.Fuel);
        allFuel.Add(_jumpEngine.Fuel);
        return allFuel;
    }

    public override void Move(Environment environment)
    {
        if (environment is IncreasedNebula)
        {
            _jumpEngine.Move(environment.JumpDistance);
        }
        else
        {
            _engineE.Move(environment.JumpDistance);
        }
    }
}