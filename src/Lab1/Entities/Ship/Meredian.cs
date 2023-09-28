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
    public Meredian()
    {
        EngineE = new EngineE();
        Deflector = new Deflector2();
        Stability = new Stability2();
        DoW = 30;
        Emitter = true;
    }

    private EngineE EngineE { get; set; }
    private Deflector2 Deflector { get; set; }
    private Stability2 Stability { get; set; }
    private int DoW { get; set; }
    private bool Emitter { get; set; }

    public void AddPhotonDeflector()
    {
        Deflector.AddPhotonDeflector();
    }

    public override Obstacle.Obstacle? GetDamage(Obstacle.Obstacle obstacle)
    {
        if (obstacle is CosmoWhale)
        {
            return null;
        }

        Obstacle.Obstacle? obs = Deflector.GetDamage(obstacle);
        return Stability.GetDamage(obs);
    }

    public override Collection<Fuel> FuelSpend()
    {
        var allFuel = new Collection<Fuel>();
        allFuel.Add(EngineE.Fuel);
        return allFuel;
    }

    public override void Move(Environment environment)
    {
        EngineE.Move(environment.JumpDistance);
    }
}