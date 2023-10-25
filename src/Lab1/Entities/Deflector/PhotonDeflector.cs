using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class PhotonDeflector : DeflectorDecorator, IPhotonicDecorator
{
    private int _charge = 3;

    public PhotonDeflector(IDeflector deflector)
        : base(deflector)
    {
    }

    public ObstacleResults HandlePhotonicDamage()
    {
        if (_charge == 0)
        {
            return new ObstacleResults.ObstacleNotReflected(-1);
        }

        _charge--;
        return new ObstacleResults.ObstacleReflected(0);
    }
}