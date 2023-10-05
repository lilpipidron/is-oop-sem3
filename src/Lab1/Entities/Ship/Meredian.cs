using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Meredian : Ship
{
    private readonly EngineE _engineE;

    private readonly Deflector2 _deflector;
    private readonly Stability2 _stability;

    public Meredian()
    {
        _engineE = new EngineE();
        _deflector = new Deflector2();
        _stability = new Stability2();
        DoW = 30;
        Emitter = true;
    }

    private bool Emitter { get; set; }
    private int DoW { get; set; }

    public void AddPhotonDeflector()
    {
        _deflector.AddPhotonDeflector();
    }

    public override Obstacle.Obstacle? GetDamage(Obstacle.Obstacle obstacle)
    {
        if (obstacle is CosmoWhale)
        {
            return null;
        }

        Obstacle.Obstacle? obs = _deflector.GetDamage(obstacle);
        return _stability.GetDamage(obs);
    }

    public override Collection<Fuel> FuelSpend()
    {
        var allFuel = new Collection<Fuel>();
        allFuel.Add(_engineE.Fuel);
        return allFuel;
    }

    public override void Move(Environment environment)
    {
        _engineE.Move(environment.JumpDistance);
    }
}