using Itmo.ObjectOrientedProgramming.Lab1.Model.Damage;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class AntimatterFlash : IObstacle
{
    private readonly Damage _damage = new(DamageType.Photon, 0);

    public Result DoDamage(Ship.Ship ship)
    {
        return ship.Deflector is null ? new CrewDied() : ship.Deflector.GetDamage(_damage);
    }
}