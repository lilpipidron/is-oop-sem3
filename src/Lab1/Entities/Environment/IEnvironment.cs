using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

public interface IEnvironment
{
    public int JumpDistance { get; init; }
    public IEnumerable<Obstacle.Obstacle> GetAllObstacles();
    public bool TryMove(Ship.Ship ship);
}