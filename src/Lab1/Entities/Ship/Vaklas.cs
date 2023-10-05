using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Vaklas : Ship
{
    private readonly Engine.Engine _engineE;
    private readonly GammaEngine _gammaEngine;
    private readonly Stability _stability;
    private Deflector _deflector;

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

    public void AddPhotonDeflector()
    {
        _deflector = new PhotonDeflector(_deflector);
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
        allFuel.Add(_gammaEngine.Fuel);
        return allFuel;
    }

    public override void Move(Environment environment)
    {
        if (environment is IncreasedNebula)
        {
            _gammaEngine.Move(environment.JumpDistance);
        }
        else
        {
            _engineE.Move(environment.JumpDistance);
        }
    }
}