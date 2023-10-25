using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class Asteroid : ISpaceObstacle
{
    private const int Damage = 10;

    public ObstacleResults DoDamage(Ship.Ship ship)
    {
        ObstacleResults result = ship.HandleDamage(Damage);
        return result;
    }
}