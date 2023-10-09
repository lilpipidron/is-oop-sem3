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
        return Use();
    }

    private bool Use()
    {
        _charge--;
        return _charge >= 0;
    }
}