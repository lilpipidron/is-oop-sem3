using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Deflector;

public class Deflector3 : Deflector
{
    public Deflector3()
        : base(1, 4, 40, 40)
    {
    }

    public override Obstacle? GetDamage(Obstacle obstacle)
    {
        return base.GetDamage(obstacle);
    }
}