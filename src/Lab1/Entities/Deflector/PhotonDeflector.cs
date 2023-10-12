using Itmo.ObjectOrientedProgramming.Lab1.Model.Damage;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Strategy;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class PhotonDeflector : DeflectorDecorator
{
    private readonly PhotonDamageStrategy _strategy;

    public PhotonDeflector(IDeflector deflector)
        : base(deflector)
    {
        _strategy = new PhotonDamageStrategy();
    }

    public override Result GetDamage(Damage damage)
    {
        Result res = _strategy.TakeDamage(damage, 0);
        return res is ObstacleNotReflected ? base.GetDamage(damage) : res;
    }
}