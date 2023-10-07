using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Meredian : Ship
{
    public Meredian()
    {
        Engine = new EngineE();
        Deflector = new Deflector2();
        Stability = new Stability2();
        DoW = 30;
        Emitter = true;
    }

    private bool Emitter { get; set; }
    private int DoW { get; set; }

    public override Obstacle.Obstacle? GetDamage(Obstacle.Obstacle obstacle)
    {
        if (obstacle is CosmoWhale)
        {
            return null;
        }

        Obstacle.Obstacle? obs = Deflector?.GetDamage(obstacle);
        return Stability?.GetDamage(obs);
    }
}