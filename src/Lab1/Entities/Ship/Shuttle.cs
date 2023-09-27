using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
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
}