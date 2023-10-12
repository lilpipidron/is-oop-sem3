using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public interface IObstacle
{
    public Result DoDamage(Ship.Ship ship);
}