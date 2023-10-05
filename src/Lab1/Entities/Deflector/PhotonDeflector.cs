using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Deflector;

public class PhotonDeflector : DeflectorDecorator
{
    private int _charge = 3;

    public PhotonDeflector(Deflector deflector)
        : base(deflector)
    {
    }

    public bool Use()
    {
        _charge--;
        return _charge >= 0;
    }

    public override Obstacle? GetDamage(Obstacle? obstacle)
    {
        if (obstacle is Antimatter)
        {
            return this.Use() ? null : obstacle;
        }

        return base.GetDamage(obstacle);
    }
}