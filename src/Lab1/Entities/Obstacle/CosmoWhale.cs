using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class CosmoWhale : Obstacle
{
    public CosmoWhale()
        : base(400)
    {
    }

    public override Result DoDamage(Ship.Ship ship)
    {
        return ship.Emitter ? new ObstacleReflected() : base.DoDamage(ship);
    }
}