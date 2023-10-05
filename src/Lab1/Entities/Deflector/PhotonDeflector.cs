using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class PhotonDeflector : DeflectorDecorator
{
    private int _charge = 3;

    public PhotonDeflector(Model.Deflector.Deflector deflector)
        : base(deflector)
    {
    }

    public bool Use()
    {
        _charge--;
        return _charge >= 0;
    }

    public override Obstacle.Obstacle? GetDamage(Obstacle.Obstacle? obstacle)
    {
        if (obstacle is Antimatter)
        {
            return this.Use() ? null : obstacle;
        }

        return base.GetDamage(obstacle);
    }
}