using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public interface IObstacle
{
    public Result DoDamage(Ship.Ship ship);
}