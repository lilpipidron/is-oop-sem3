using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class PhotonDeflector : DeflectorDecorator
{
    private int _charge = 3;

    public PhotonDeflector(IDeflector deflector)
        : base(deflector)
    {
    }

    public Result PhotonDeflect()
    {
        _charge--;
        return _charge >= 0 ? new ObstacleReflected() : new ObstacleNotReflected();
    }
}