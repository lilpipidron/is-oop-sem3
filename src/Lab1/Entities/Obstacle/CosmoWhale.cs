using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class CosmoWhale : Obstacle
{
    public CosmoWhale()
        : base(100, 400)
    {
    }

    public override Result DoDamage(Ship.Ship ship)
    {
        return ship.Emitter is true ? new ObstacleReflected() : base.DoDamage(ship);
    }
}