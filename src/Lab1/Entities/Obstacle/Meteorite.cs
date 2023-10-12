using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class Meteorite : IObstacle
{
    private const int Damage = 40;

    public Result DoDamage(Ship.Ship ship)
    {
        Result result = ship.GetDamage(Damage);
        return result is ObstacleNotReflected ? new DestroyShip() : result;
    }
}