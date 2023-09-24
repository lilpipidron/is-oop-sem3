using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Deflector;

public class Deflector2 : Deflector
{
    public Deflector2()
        : base(3, 10, 0, 30)
    {
    }

    public override Obstacle? GetDamage(Obstacle obstacle)
    {
        return base.GetDamage(obstacle);
    }
}