namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class PhotonDeflector : DeflectorDecorator
{
    private int _charge = 3;

    public PhotonDeflector(Deflector deflector)
        : base(deflector)
    {
    }

    public override bool PhotonDeflect()
    {
        _charge--;
        return _charge >= 0;
    }
}