using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
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

    public override Obstacle.Obstacle? GetDamage(Obstacle.Obstacle obstacle)
    {
        Obstacle.Obstacle? obs = Deflector.GetDamage(obstacle);
        return Stability.GetDamage(obs);
    }
}