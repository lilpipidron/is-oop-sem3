using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class PhotonDeflector : DeflectorDecorator, IPhotonicDecorator
{
    private int _charge = 3;

    public PhotonDeflector(IDeflector deflector)
        : base(deflector)
    {
    }

    public Result HandlePhotonicDamage()
    {
        if (_charge == 0)
        {
            return new Result.CrewDied();
        }

        _charge--;
        return new Result.ObstacleReflected(0);
    }
}