using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Vaklas : Ship
{
    public Vaklas()
    {
        EngineE = new EngineE();
        GammaEngine = new GammaEngine();
        JumpDistance = GammaEngine.JumpDistance;
        Deflector = new Deflector1();
        Stability = new Stability2();
        DoW = 30;
    }

    private EngineE EngineE { get; set; }
    private GammaEngine GammaEngine { get; set; }
    private Deflector1 Deflector { get; set; }
    private Stability2 Stability { get; set; }
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

    public override Collection<Fuel> FuelSpend()
    {
        var allFuel = new Collection<Fuel>();
        allFuel.Add(EngineE.Fuel);
        allFuel.Add(GammaEngine.Fuel);
        return allFuel;
    }

    public override void Move(Environment environment)
    {
        if (environment is IncreasedNebula)
        {
            GammaEngine.Move(environment.JumpDistance);
        }
        else
        {
            EngineE.Move(environment.JumpDistance);
        }
    }
}