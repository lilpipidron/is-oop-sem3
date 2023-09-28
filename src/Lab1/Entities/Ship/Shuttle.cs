using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Shuttle : Ship
{
    public Shuttle()
    {
        Engine = new EngineC();
        Stability = new Stability1();
        DoW = 20;
    }

    private EngineC Engine { get; set; }
    private Stability1 Stability { get; set; }
    private int DoW { get; set; }

    public override Obstacle.Obstacle? GetDamage(Obstacle.Obstacle obstacle)
    {
        return Stability.GetDamage(obstacle);
    }

    public override Collection<Fuel> FuelSpend()
    {
        var allFuel = new Collection<Fuel>();
        allFuel.Add(Engine.Fuel);
        return allFuel;
    }

    public override void Move(Environment environment)
    {
        if (environment is NitrineNebula)
        {
            Engine.Move(environment.JumpDistance * 100);
            return;
        }

        Engine.Move(environment.JumpDistance);
    }
}