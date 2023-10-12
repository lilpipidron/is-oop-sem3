using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

public interface IEnvironment
{
    public IEnumerable<Obstacle.IObstacle> GetAllObstacles();
    public bool TryMove(Ship.Ship ship);
}