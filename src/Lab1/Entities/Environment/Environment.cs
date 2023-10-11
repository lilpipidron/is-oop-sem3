using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

public abstract class Environment
{
    protected Environment(int jumpDistance)
    {
        JumpDistance = jumpDistance;
    }

    protected int JumpDistance { get; private set; }
    public abstract IEnumerable<Obstacle.Obstacle> GetAllObstacles();
    public abstract bool TryMove(Ship.Ship ship);
}