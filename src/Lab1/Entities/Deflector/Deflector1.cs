using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Deflector;

public class Deflector1 : Deflector
{
    public Deflector1()
        : base(2, 4, 0, 4)
    {
    }

    public override Obstacle? GetDamage(Obstacle obstacle)
    {
        return base.GetDamage(obstacle);
    }
}