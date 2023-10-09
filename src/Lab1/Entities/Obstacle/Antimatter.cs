using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class Antimatter : Obstacle
{
    public override Result DoDamage(Ship.Ship ship)
    {
        if (ship.Deflector is null)
        {
            return new CrewDied();
        }

        return ship.Deflector.PhotonDeflect() ? new ObstacleReflected() : new CrewDied();
    }
}