using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class AntimatterFlash : IIncreasedNebulaObstacle
{
    public ObstacleResults DoDamage(Ship.Ship ship)
    {
        if (ship.Deflector is IPhotonicDecorator photonicDecorator)
        {
            return photonicDecorator.HandlePhotonicDamage();
        }

        return new ObstacleResults.ObstacleNotReflected(0);
    }
}