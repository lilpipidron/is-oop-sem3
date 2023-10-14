using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class Asteroid : ISpaceObstacle
{
    private const int Damage = 10;

    public Result DoDamage(Ship.Ship ship)
    {
        Result result = ship.HandleDamage(Damage);
        return result is Result.ObstacleNotReflected ? new Result.DestroyShip() : result;
    }
}